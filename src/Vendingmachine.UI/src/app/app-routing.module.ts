import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { VendingInventoryComponent } from './components/vending-inventory/vending-inventory.component';
import { VendingMachineComponent } from './pages/vending-machine/vending-machine.component';
import { TransactionsComponent } from './components/transactions/transactions.component';

const routes: Routes = [
  {
    path: '',
    component: VendingMachineComponent
  },
  {
    path: 'transactions',
    component: TransactionsComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
