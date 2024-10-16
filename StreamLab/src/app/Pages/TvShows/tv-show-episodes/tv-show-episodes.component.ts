import { Component } from '@angular/core';
import { ScriptService } from '../../../Services/script.service';
import { RouterLink, RouterLinkActive } from '@angular/router';
@Component({
  selector: 'app-tv-show-episodes',
  standalone: true,
  imports: [RouterLink,RouterLinkActive],
  templateUrl: './tv-show-episodes.component.html',
  styleUrl: './tv-show-episodes.component.css'
})
export class TvShowEpisodesComponent {
  constructor(private scriptService: ScriptService) { }
  ngAfterViewInit() {
    this.scriptService.RemoveAllBaseScripts();
    this.scriptService.LoadAllBaseScripts();
  }
}
