import { Component, OnInit } from '@angular/core';
import { Product } from "src/app/models/product.model";
import { VendingServiceService } from '../../services/vending-service.service';

@Component({
  selector: 'app-vending-inventory',
  templateUrl: './vending-inventory.component.html',
  styleUrls: ['./vending-inventory.component.css'],
  providers: [VendingServiceService]
})
export class VendingInventoryComponent implements OnInit {
  
  public inventory: Product[]=[];
    constructor(public vendingService: VendingServiceService) { 
    }
  
    ngOnInit(): void {
      this.vendingService.getInventory().subscribe(item => {
        this.inventory = item;
      });
      console.log(this.inventory);
    }
}
