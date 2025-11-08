import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { AppSendMessage } from './app-send-message/app-send-message';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, AppSendMessage],
  templateUrl: './app.html',
  styleUrls: ['./app.scss'],
  standalone: true
})
export class App {
  protected readonly title = signal('messaging');
}
