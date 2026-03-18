import { Directive, Input, HostBinding } from '@angular/core';

@Directive({
  selector: '[appPriceHighlight]',
  standalone: true
})
export class PriceHighlightDirective {

  @Input() appPriceHighlight = 0;

  @HostBinding('style.color') color!: string;
  @HostBinding('style.fontWeight') weight!: string;
  @HostBinding('style.borderLeft') border!: string;

  ngOnInit() {
    if (this.appPriceHighlight > 50000) {
      this.color = 'red';
      this.weight = 'bold';
      this.border = '5px solid #e74c3c';
    } else {
      this.color = 'green';
      this.weight = 'normal';
      this.border = '5px solid #27ae60';
    }
  }
}