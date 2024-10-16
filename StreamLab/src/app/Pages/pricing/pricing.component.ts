import { Component } from '@angular/core';
import { ScriptService } from '../../Services/script.service';
import { RouterLink, RouterLinkActive } from '@angular/router';

@Component({
  selector: 'app-pricing',
  standalone: true,
  imports: [RouterLink,RouterLinkActive],
  templateUrl: './pricing.component.html',
  styleUrl: './pricing.component.css'
})
export class PricingComponent {
  constructor(private scriptService: ScriptService) { }
  ngAfterViewInit() {
    this.scriptService.RemoveAllBaseScripts();
    this.scriptService.LoadAllBaseScripts();
  }
}
