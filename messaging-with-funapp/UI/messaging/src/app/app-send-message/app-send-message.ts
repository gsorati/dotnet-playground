import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MessageService } from '../services/MessageService';
import { FormsModule } from '@angular/forms';
@Component({
  selector: 'app-app-send-message',
  imports: [CommonModule, FormsModule],
  standalone: true,
  templateUrl: './app-send-message.html',
  styleUrls: ['./app-send-message.scss'],
})
export class AppSendMessage {
  message: string = '';
  response = '';
  constructor(private messageService: MessageService) { }

  sendMessage() {
    this.messageService.sendMessage(this.message).subscribe({
      next: (response) => {
        this.response = response;
      },
      error: (error) => {
        console.log('Error in sending message:', error);
      }
    });
  }
}
