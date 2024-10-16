import { Component } from '@angular/core';
import { ScriptService } from '../../../Services/script.service';
import { RouterLink, RouterLinkActive } from '@angular/router';

@Component({
  selector: 'app-blogs-index',
  standalone: true,
  imports: [RouterLink,RouterLinkActive],
  templateUrl: './blogs-index.component.html',
  styleUrl: './blogs-index.component.css'
})
export class BlogsIndexComponent {
  constructor(private scriptService: ScriptService) { }
  ngAfterViewInit() {
    this.scriptService.RemoveAllBaseScripts();
    this.scriptService.LoadAllBaseScripts();
  }
}
