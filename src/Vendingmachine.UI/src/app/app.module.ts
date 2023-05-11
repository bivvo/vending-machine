import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { VendingInventoryComponent } from './components/vending-inventory/vending-inventory.component';
import { HttpClientModule } from '@angular/common/http';
import { TransactionsComponent } from './components/transactions/transactions.component';
import { VendItemsComponent } from './components/vend-items/vend-items.component';
import { FormsModule } from '@angular/forms';
import { VendingMachineComponent } from './pages/vending-machine/vending-machine.component';

@NgModule({
  declarations: [
    AppComponent,
    VendingInventoryComponent,
    TransactionsComponent,
    VendItemsComponent,
    VendingMachineComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
