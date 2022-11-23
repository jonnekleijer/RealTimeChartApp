import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { SignalRService } from '../services/signalr.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css'],
  providers: [SignalRService]
})
export class ListComponent {
  constructor(public signalRService: SignalRService, private http: HttpClient) { }

}
