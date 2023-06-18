import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TopOrderService } from 'src/app/Shared/Service/topOrder.service';

import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import {
  MatDatepickerModule,
  MatDatepicker,
} from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatNativeDateModule } from '@angular/material/core';

import {
  FormBuilder,
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
} from '@angular/forms';
import {
  MomentDateAdapter,
  MAT_MOMENT_DATE_ADAPTER_OPTIONS,
} from '@angular/material-moment-adapter';
import {
  DateAdapter,
  MAT_DATE_FORMATS,
  MAT_DATE_LOCALE,
} from '@angular/material/core';

import * as _moment from 'moment';
import { Moment } from 'moment';

const moment = _moment;

export const MY_FORMATS = {
  parse: {
    dateInput: 'MM/YYYY',
  },
  display: {
    dateInput: 'MM/YYYY',
    monthYearLabel: 'MMM YYYY',
    dateA11yLabel: 'LL',
    monthYearA11yLabel: 'MMMM YYYY',
  },
};

const matModules = [
  MatFormFieldModule,
  MatCardModule,
  MatButtonModule,
  MatInputModule,
  MatDatepickerModule,
  MatNativeDateModule,
  MatIconModule,
];

@Component({
  selector: 'app-top-orders',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule, ...matModules],
  templateUrl: './top-orders.component.html',
  styleUrls: ['./top-orders.component.css'],
  providers: [
    {
      provide: DateAdapter,
      useClass: MomentDateAdapter,
      deps: [MAT_DATE_LOCALE, MAT_MOMENT_DATE_ADAPTER_OPTIONS],
    },
    { provide: MAT_DATE_FORMATS, useValue: MY_FORMATS },
  ],
  encapsulation: ViewEncapsulation.None,
})
export class TopOrdersComponent implements OnInit {
  constructor(
    private topOrderService: TopOrderService,
    private fb: FormBuilder
  ) {}

  imageBaseUrl = 'https://localhost:44333/resources/';

  ngOnInit(): void {
    this.number = this.fb.group({
      number: new FormControl(5),
    });
  }

  topOrders$ = this.topOrderService.getTopOrderedProducts();

  date = new FormControl(moment());
  number!: FormGroup;

  setMonthAndYear(
    normalizedMonthAndYear: Moment,
    datepicker: MatDatepicker<Moment>
  ) {
    const ctrlValue = this.date.value!;
    ctrlValue.month(normalizedMonthAndYear.month());
    ctrlValue.year(normalizedMonthAndYear.year());
    this.date.setValue(ctrlValue);
    datepicker.close();

    let month: number = this.date.value?.month() ?? 0;
    let year: number = this.date.value?.year() ?? 0;
    month = month + 1;
    this.topOrders$ = this.topOrderService.getTopOrderedProducts(
      this.number.value.number,
      month,
      year
    );
  }

}
