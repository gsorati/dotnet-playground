import { Injectable } from '@angular/core'
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({ providedIn: 'root' })
export class MessageService
{
  constructor(private http: HttpClient) { }
  sendMessage(message: string): Observable<any>
  {
    return this.http.post('https://<your-function-app>.azurewebsites.net/api/SendMessage', { message }, { responseType: 'text' });
  }
}
