import { Component } from '@angular/core';
import { ScriptService } from '../../../Services/script.service';
import { RouterLink, RouterLinkActive } from '@angular/router';

@Component({
  selector: 'app-single-tv-show',
  standalone: true,
  imports: [RouterLink,RouterLinkActive],
  templateUrl: './single-tv-show.component.html',
  styleUrl: './single-tv-show.component.css'
})
export class SingleTvShowComponent {
  constructor(private scriptService: ScriptService) { }
  ngAfterViewInit() {
    this.scriptService.RemoveAllBaseScripts();
    this.scriptService.LoadAllBaseScripts();
  }
}
