import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ThemeService } from '../core/services/theme.service';
import { PlatformComponent } from './platform.component';

describe('PlatformComponent', () => {
  let component: PlatformComponent;
  let fixture: ComponentFixture<PlatformComponent>;
  let themeService: ThemeService; 

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PlatformComponent],
      providers: [ThemeService]
    }).compileComponents();

    fixture = TestBed.createComponent(PlatformComponent);
    component = fixture.componentInstance;
    themeService = TestBed.inject(ThemeService);
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should toggle theme', () => {
    spyOn(themeService, 'toggleTheme');
    component.toggleTheme();
    expect(themeService.toggleTheme).toHaveBeenCalled();
  });
});