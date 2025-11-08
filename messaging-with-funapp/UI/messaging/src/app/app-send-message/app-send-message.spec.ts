import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AppSendMessage } from './app-send-message';

describe('AppSendMessage', () => {
  let component: AppSendMessage;
  let fixture: ComponentFixture<AppSendMessage>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AppSendMessage]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AppSendMessage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
