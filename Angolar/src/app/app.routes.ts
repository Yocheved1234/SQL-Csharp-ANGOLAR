import { RouterModule, Routes } from '@angular/router';
import { LogInComponent } from './comps/log-in/log-in.component';
import { SingInComponent } from './comps/sing-in/sing-in.component';
import { WinnersComponent } from './comps/winners/winners.component';
import { ProductComponent } from './comps/product/product.component';
import { BigProductComponent } from './comps/big-product/big-product.component';
import { NgModule } from '@angular/core';
import { CartComponent } from './comps/cart/cart.component';
import { HomeComponent } from './comps/home/home.component';
import { YourBuyComponent } from './comps/your-buy/your-buy.component';
import { BuyDetailsComponent } from './comps/buy-details/buy-details.component';

export const routes: Routes = [
    { path: 'product/big/:id', component: BigProductComponent , title: 'Product Details'},
    { path: 'login', component: LogInComponent, title: 'Login' },
    { path: 'singin', component: SingInComponent , title:'Sing In'},
    { path: 'winner', component: WinnersComponent , title:'Winners'},
    { path: 'product', component: ProductComponent , title:'All Products'},
    { path: 'cart', component: CartComponent , title:'Cart'},
    { path: 'home', component: HomeComponent , title:'Home'},
    { path: 'yourBuy', component: YourBuyComponent , title:'Your Sales'},
    { path: 'yourBuy/buy-details/:id', component: BuyDetailsComponent , title:'Your Sales Details'},
    { path: '', component: HomeComponent , title:'Home'}

];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
