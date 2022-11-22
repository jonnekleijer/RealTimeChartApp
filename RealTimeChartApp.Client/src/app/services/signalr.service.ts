import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr'
import { ChartModel } from '../interface/chartmodel.model';
import { TimeSerieModel } from '../interface/timeseriemodel.model';

@Injectable({
  providedIn: 'root'
})
export class SignalRService {
  public data: ChartModel[]
  private hubConnection: signalR.HubConnection

  public startConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('https://localhost:5000/timeserie', {
        skipNegotiation: true,
        transport: signalR.HttpTransportType.WebSockets
      })
      .build();

    this.hubConnection
      .start()
      .then(() => console.log('Connection started'))
      .catch(err => console.log(`Error while starting connection: ${err}`))
  }

  public addReceiveTimeSerieListener = () => {
    this.hubConnection.on('receivetimeserie', (timeseries : TimeSerieModel[]) => {
      this.data = timeseries.map(t => <ChartModel>{
        x: t.data.map(d => d.x),
        y: t.data.map(d => d.y),
        type: "scatter",
        mode: "lines+points"
      });
    });
  }
}
