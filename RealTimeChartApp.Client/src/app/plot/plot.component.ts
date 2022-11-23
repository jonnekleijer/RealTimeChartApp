import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { SignalRService } from './../services/signalr.service';

@Component({
  selector: 'app-root',
  templateUrl: './plot.component.html',
  styleUrls: ['./plot.component.css'],
  providers: [SignalRService]
})
export class PlotComponent {
  layout = {autosize: true, title: 'A Real Time Plot'};
  constructor(public signalRService: SignalRService, private http: HttpClient) { }

  ngOnInit() {
    this.signalRService.startConnection('plot');
    this.signalRService.addReceiveTimeSerieListener();
    this.startHttpRequest();
  }

  private startHttpRequest = () => {
    this.http.get('https://localhost:5000/api/timeserie')
    .subscribe(res => {
      console.log(res);
    })
  }
}
