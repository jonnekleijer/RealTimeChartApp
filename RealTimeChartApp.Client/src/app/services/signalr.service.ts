import { Injectable } from '@angular/core';
import { ChartModel } from '../interface/chartmodel.model';
import * as signalR from '@microsoft/signalr'
import { TimeSerieModel } from '../interface/TimeSerieModel.model';

@Injectable({
  providedIn: 'root'
})
export class SignalRService {
  public data: ChartModel[];
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
        data: t.data,
        label: t.name
      });
    });
  }
}
