import { Routes } from '@angular/router';
import { UrlResultComponent } from './components/url-result/url-result';
import { UrlFormComponent } from './components/url-form/url-form';
import { UrlRedirectComponent } from './components/url-redirect/url-redirect';

export const routes: Routes = [
  { path: '', component: UrlFormComponent },
  { path: 'resultado', component: UrlResultComponent },
  { path: ':code', component: UrlRedirectComponent }
];
