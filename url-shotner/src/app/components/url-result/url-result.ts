import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-url-result',
  imports: [CommonModule],
  templateUrl: './url-result.html',
  styleUrl: './url-result.css',
})
export class UrlResultComponent {
  // Suas propriedades
  titulo: string = 'Resultado';
  shortnerResponse?: ShortnerResponse | null = null;
  shortedUrl: string = '';

  constructor(private router: Router) {
    const navigation = this.router.currentNavigation();
    this.shortnerResponse = navigation?.extras.state as ShortnerResponse;
    this.shortedUrl = `${environment.appUrl}/${this.shortnerResponse.shortCode}`;

    if (!this.shortnerResponse) {
      this.router.navigate(['/']);
    }

  }

  copiar(): void {
    navigator.clipboard.writeText(this.shortedUrl || '');
    // alert('✅ URL copiada para área de transferência!');
  }

  novaUrl() {
    this.router.navigate(['/']);
  }
}
