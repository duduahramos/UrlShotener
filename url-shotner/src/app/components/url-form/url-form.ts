import { CommonModule } from '@angular/common';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-url-form',
  imports: [FormsModule, CommonModule],
  templateUrl: './url-form.html',
  styleUrl: './url-form.css',
})
export class UrlFormComponent {
  url: string = "";
  isLoading: boolean = false;
  error: string = "";

  constructor(private http: HttpClient, private router: Router ) {}

  encurtar(): void {
    if (!this.url) return;

    this.isLoading = true;
    
    const shortUrlEndpoint = `${environment.apiUrl}/shortner`;
    const payload: ShortnerRequest = {
      originalUrl: this.url
    };

    const subscription = this.http.post<ShortnerResponse>(shortUrlEndpoint, payload).subscribe({
      next: (urlResponse) => {
        this.router.navigate(["/resultado"], {
          state: urlResponse
        });
      },
      error: (err: HttpErrorResponse) => {
        console.log('━━━━━━━━━━━━━━━━━━━━━━');
        console.error('❌ ERRO NA REQUISIÇÃO!');
        console.error('❌ Erro completo:', err);
        console.error('❌ Status:', err.status);
        console.error('❌ StatusText:', err.statusText);
        console.error('❌ Message:', err.message);
        console.error('❌ URL:', err.url);
        console.log('━━━━━━━━━━━━━━━━━━━━━━');
        
        this.error = `Erro: ${err.status} - ${err.statusText}`;
        this.isLoading = false;
      },
      complete: () => {
        console.log('🔵 6. Requisição finalizada (complete)');
      }
    });
    
    console.log('🔵 7. Subscribe retornou:', subscription);
    console.log('━━━━━━━━━━━━━━━━━━━━━━');
  }

  limpar(): void {
    this.url = "";
    this.error = "";
  }
}
