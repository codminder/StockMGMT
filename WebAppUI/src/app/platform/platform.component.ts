import { Component } from '@angular/core';
import { Router, RouterModule, RouterOutlet } from '@angular/router';
import { NavigationComponent } from './navigation/navigation.component';
import { AuthService } from '../core/services/auth.service';
import { CommonModule } from '@angular/common';
import { ThemeService } from '../core/services/theme.service';

@Component({
  selector: 'app-platform',
  standalone: true,
  imports: [RouterOutlet, NavigationComponent, CommonModule, RouterModule],
  templateUrl: './platform.component.html',
  styleUrl: './platform.component.scss'
})
export class PlatformComponent {
  constructor(private authService: AuthService, private router: Router, private themeService: ThemeService) { }
  public logout() {
    this.authService.logout();
    this.router.navigate(['/login']);
  }

  public toggleTheme(): void {
    this.themeService.toggleTheme();
  }
}
