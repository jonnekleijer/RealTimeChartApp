import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import * as PlotlyJS from 'plotly.js-dist-min';
import { PlotlyModule } from 'angular-plotly.js';
import { PlotComponent } from './plot.component';

PlotlyModule.plotlyjs = PlotlyJS;

@NgModule({
  declarations: [
    PlotComponent
  ],
  imports: [
    CommonModule,
    PlotlyModule,
  ]
})
export class PlotModule { }
