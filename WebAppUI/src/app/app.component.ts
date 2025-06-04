import { Component } from '@angular/core';
import { PlatformComponent } from './platform/platform.component';

@Component({
  selector: 'app-root',
  imports: [PlatformComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'WebAppUI';
}
