import { Directive, Input, HostListener, HostBinding } from '@angular/core';

@Directive({
  selector: '[appClickBlock]',
  standalone: true
})
export class ClickBlockDirective {

  @Input() appClickBlock = true;

  @HostBinding('style.opacity') opacity!: string;
  @HostBinding('style.cursor') cursor!: string;

  ngOnInit() {
    this.updateUI();
  }

  ngOnChanges() {
    this.updateUI();
  }

  updateUI() {
    if (!this.appClickBlock) {
      this.opacity = '0.5';
      this.cursor = 'not-allowed';
    } else {
      this.opacity = '1';
      this.cursor = 'pointer';
    }
  }

  @HostListener('click', ['$event'])
  onClick(event: Event) {
    if (!this.appClickBlock) {
      event.preventDefault();
      event.stopPropagation();
      console.log('Click blocked ❌');
    }
  }
}