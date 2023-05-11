import { Component } from '@angular/core';
import { VendingServiceService } from '../../services/vending-service.service';
import { Transaction } from 'src/app/models/transaction.model';

@Component({
  selector: 'app-transactions',
  templateUrl: './transactions.component.html',
  styleUrls: ['./transactions.component.css'],
  providers: [VendingServiceService]
})
export class TransactionsComponent {
  transactions: Transaction[] = [];
  constructor(public vendingService: VendingServiceService) { 
  }

  ngOnInit(): void {
    this.vendingService.getTransactions().subscribe(transactions => {
      this.transactions = transactions;
      console.log(JSON.stringify(this.transactions));
    });
    
  }

  getTotal(transaction: Transaction): number {
    return transaction.products.reduce((total, item) => total + item.price, 0);
  }
}
