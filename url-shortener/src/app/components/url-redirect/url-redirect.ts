import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-url-redirect',
  imports: [],
  templateUrl: './url-redirect.html',
  styleUrl: './url-redirect.css',
})
export class UrlRedirectComponent implements OnInit {
  shortCode: string = '';
  errorMessage: string = '';
  isLoading: boolean = true;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private http: HttpClient
  ) { }

  ngOnInit(): void {
    this.shortCode = this.route.snapshot.params['code'];

    this.buscarUrlOriginal();
  }

  buscarUrlOriginal(): void {
    const apiUrl = `${environment.apiUrl}/${this.shortCode}`;

    this.http.get<ShortenerResponse>(apiUrl).subscribe({
      next: (response) => {
        // Redireciona para a URL original
        window.location.href = response.originalUrl;
      },
      error: (err) => {
        this.isLoading = false;
        this.errorMessage = 'URL encurtada não encontrada ou expirada.';
        console.error('Erro ao buscar URL:', err);
      }
    });
  }

  voltarHome(): void {
    this.router.navigate(['/']);
  }
}
