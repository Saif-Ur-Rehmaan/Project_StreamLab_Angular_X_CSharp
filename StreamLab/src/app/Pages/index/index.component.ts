import { AfterViewInit, Component } from '@angular/core';
import { ScriptService } from '../../Services/script.service';
import { RouterLink, RouterLinkActive } from '@angular/router';

@Component({
  selector: 'app-index',
  standalone: true,
  imports: [RouterLink,RouterLinkActive],
  templateUrl: './index.component.html',
  styleUrl: './index.component.css',


})
export class IndexComponent implements AfterViewInit{

  constructor(private scriptService: ScriptService) { }
  ngAfterViewInit() {
    
    this.scriptService.RemoveAllBaseScripts();
    this.scriptService.LoadAllBaseScripts();
      
  
  }


}
