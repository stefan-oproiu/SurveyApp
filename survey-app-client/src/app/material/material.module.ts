import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatSnackBarModule, MatSnackBar } from '@angular/material/snack-bar';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatRippleModule } from '@angular/material/core';
import { MatBadgeModule } from '@angular/material/badge';
import { MatTabsModule } from '@angular/material/tabs';
import { ScrollDispatchModule } from '@angular/cdk/scrolling';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatDividerModule } from '@angular/material/divider';
import { MatDialogModule } from '@angular/material/dialog';
import { MatListModule } from '@angular/material/list';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatSnackBarModule,
    MatCardModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule,
    MatSidenavModule,
    MatTooltipModule,
    MatRippleModule,
    MatBadgeModule,
    MatTabsModule,
    ScrollDispatchModule,
    MatExpansionModule,
    MatProgressSpinnerModule,
    MatGridListModule,
    MatDividerModule,
    MatDialogModule,
    MatListModule
  ],
  exports: [
    MatToolbarModule,
    MatSnackBarModule,
    MatCardModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule,
    MatSidenavModule,
    MatTooltipModule,
    MatRippleModule,
    MatBadgeModule,
    MatTabsModule,
    ScrollDispatchModule,
    MatExpansionModule,
    MatProgressSpinnerModule,
    MatGridListModule,
    MatDividerModule,
    MatDialogModule,
    MatListModule
  ],
  providers: [MatSnackBar]
})
export class MaterialModule { }
