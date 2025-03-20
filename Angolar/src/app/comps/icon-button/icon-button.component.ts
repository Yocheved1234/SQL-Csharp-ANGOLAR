import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-icon-button',
  standalone: true,
  imports: [],
  templateUrl: './icon-button.component.html',
  styleUrl: './icon-button.component.css'
})
export class IconButtonComponent {
  @Input() class: string | undefined;
  @Input() icon: string | undefined;
  @Input() label: string | undefined;
  @Input() disabled: boolean = false; 
  @Output() buttonClick = new EventEmitter<void>();

  onButtonClick() {
    if (!this.disabled) {
      this.buttonClick.emit();
    }
  }
}
