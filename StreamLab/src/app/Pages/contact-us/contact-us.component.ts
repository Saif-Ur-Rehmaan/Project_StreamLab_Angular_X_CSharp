import { Component } from '@angular/core';
import { ScriptService } from '../../Services/script.service';
import { RouterLink, RouterLinkActive } from '@angular/router';

@Component({
  selector: 'app-contact-us',
  standalone: true,
  imports: [RouterLink,RouterLinkActive],
  templateUrl: './contact-us.component.html',
  styleUrl: './contact-us.component.css'
})
export class ContactUsComponent {
  constructor(private scriptService: ScriptService) { }
  ngAfterViewInit() {
    this.scriptService.RemoveAllBaseScripts();
    this.scriptService.LoadAllBaseScripts();
  }
}
