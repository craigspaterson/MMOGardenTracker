import { Activities } from './activities.enum';

export class CropActivity {
  cropActivityId: number;
  cropId: number;
  activityType: Activities;
  activityDate: Date;
  notes: string;
}
