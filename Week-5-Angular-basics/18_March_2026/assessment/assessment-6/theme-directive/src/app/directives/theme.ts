import { Directive, Input, HostBinding, OnChanges } from '@angular/core';

@Directive({
  selector: '[appTheme]',
  standalone: true
})
export class ThemeDirective implements OnChanges {

  @Input() appTheme: 'light' | 'dark' = 'light';

  @HostBinding('style.backgroundColor') bg!: string;
  @HostBinding('style.color') color!: string;
  @HostBinding('style.transition') transition = '0.3s ease';

  ngOnChanges() {
    this.applyTheme();
  }

  applyTheme() {
    if (this.appTheme === 'dark') {
      this.bg = '#1e1e1e';
      this.color = '#f5f5f5';
    } else {
      this.bg = '#ffffff';
      this.color = '#2c3e50';
    }
  }
}