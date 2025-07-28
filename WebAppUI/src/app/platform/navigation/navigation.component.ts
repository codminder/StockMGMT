import { Component } from '@angular/core';
import { MatListModule } from '@angular/material/list';
import { RouterModule } from '@angular/router';
import { MatIconModule } from '@angular/material/icon';
import { CommonModule } from '@angular/common';

@Component({
  standalone: true,
  selector: 'app-navigation',
  imports: [
    CommonModule,
    RouterModule,
    MatIconModule,
    MatListModule
  ],
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.scss'] 
})
export class NavigationComponent { }