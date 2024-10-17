import { Component } from '@angular/core';
import { ScriptService } from '../../Services/script.service';

@Component({
  selector: 'app-recover-password',
  standalone: true,
  imports: [],
  templateUrl: './recover-password.component.html',
  styleUrl: './recover-password.component.css'
})
export class RecoverPasswordComponent {
  constructor(private scriptService: ScriptService) { }
  ngAfterViewInit() {
    this.scriptService.RemoveAllBaseScripts();
    this.scriptService.LoadAllBaseScripts();
  }
}
