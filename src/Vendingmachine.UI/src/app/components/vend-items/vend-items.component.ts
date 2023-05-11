import { Component, OnInit } from '@angular/core';
import { Product } from "src/app/models/product.model";
import { VendingServiceService } from '../../services/vending-service.service';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-vend-items',
  templateUrl: './vend-items.component.html',
  styleUrls: ['./vend-items.component.css'],
  providers: [VendingServiceService]
})

export class VendItemsComponent implements OnInit {
  inventory: Product[]=[];
  selectedItems: Product[] = [];
  total: number = 0;
  constructor(public vendingService: VendingServiceService) { 
  }

  ngOnInit(): void {
    this.vendingService.getInventory().subscribe(item => {
      this.inventory = item;
    });
    console.log(this.inventory);
  }

  onAddItem(item: Product) {
    console.log(JSON.stringify(item));
    this.vendingService.getInventory().pipe(
        map(products => products.find(p => p.id === item.id))
    ).subscribe(i => {   
      if (i) {
        this.total += i.price * item.quantity;
        if(i.quantity > item.quantity)
          i.quantity = i.quantity -= item.quantity;
      }
      console.log(JSON.stringify(i));
      this.selectedItems.push(item as Product);
    });
  }

  onRemoveItem(item: Product) {
    // const index = this.selectedItems.indexOf(item);

    // if (index > -1) {
    //   const inventoryItem = this.inventory.find(i => i.id === item.id);
    //   if (inventoryItem) {
    //     this.total -= inventoryItem.price * item.quantity;
    //   }
    //   this.selectedItems.splice(index, 1);
    // }
  }

  onSubmit() {
    // this.vendingService.purchaseItems(this.selectedItems)
    //   .subscribe(items => {
    //     this.inventory = items;
    //     this.selectedItems = [];
    //     this.total = 0;
    //   });
  }

  onPurchase() {

  }
}
