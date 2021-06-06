import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserComponent } from './user/user.component';
import { ListingComponent } from './listing/listing.component';
import { UserRouterModule } from './user-routing.module';
import { CoreModule } from '../core/core.module';
import { SharedModule } from '../shared/shared.module';

@NgModule({
    declarations: [UserComponent, ListingComponent],
    imports: [CommonModule, CoreModule, SharedModule, UserRouterModule],
})
export class UserModule {}
