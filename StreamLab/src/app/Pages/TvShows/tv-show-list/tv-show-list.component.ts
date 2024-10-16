import { Component } from '@angular/core';
import { ScriptService } from '../../../Services/script.service';
import { RouterLink, RouterLinkActive } from '@angular/router';
@Component({
  selector: 'app-tv-show-list',
  standalone: true,
  imports: [RouterLink,RouterLinkActive],
  templateUrl: './tv-show-list.component.html',
  styleUrl: './tv-show-list.component.css'
})
export class TvShowListComponent {
  constructor(private scriptService: ScriptService) { }
  ngAfterViewInit() {
    this.scriptService.RemoveAllBaseScripts();
    this.scriptService.LoadAllBaseScripts();
  }
}
