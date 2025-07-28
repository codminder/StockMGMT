import { Injectable } from "@angular/core";

@Injectable({ providedIn: 'root' })
export class ThemeService {
    public toggleTheme() {
        document.documentElement.classList.toggle('dark-theme');
    }

    public isDarkTheme(): boolean {
        return document.documentElement.classList.contains('dark-theme');
    }
}

