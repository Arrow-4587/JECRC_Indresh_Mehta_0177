import { Directive, Input, HostBinding } from '@angular/core';

@Directive({
  selector: '[appStatusColor]',
  standalone: true
})
export class StatusColorDirective {

  @Input() appStatusColor = 0;

  @HostBinding('style.color') color!: string;
  @HostBinding('style.fontWeight') weight!: string;

  ngOnInit() {
    this.updateColor();
  }

  ngOnChanges() {
    this.updateColor();
  }

  updateColor() {
    if (this.appStatusColor >= 50) {
      this.color = '#27ae60'; // green
      this.weight = 'bold';
    } else {
      this.color = '#e74c3c'; // red
      this.weight = 'bold';
    }
  }
}