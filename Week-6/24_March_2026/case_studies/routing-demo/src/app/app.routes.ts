import { Routes } from '@angular/router';
import { Home } from './component/home/home';
import { Contact } from './component/contact/contact';
import { ProductComponent } from './component/product/product';
import { Error } from './component/error/error';
import { ProductGaurdService } from './product-gaurd.service';
import { ProductDetail } from './component/product-detail/product-detail';

export const routes: Routes = [
  { path: 'Home', component: Home },
  { path: 'contact', component: Contact },
  { path: 'products', component: ProductComponent },
  { path: 'product/:id', component: ProductDetail, canActivate: [ProductGaurdService]},
  { path: '', redirectTo: '/Home', pathMatch: 'full' },
  { path: '**', component: Error }
];
