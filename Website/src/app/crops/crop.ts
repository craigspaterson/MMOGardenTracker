import { CropActivity } from './crop-activity';

/**
 *
 *
 * @export
 * @class Crop
 */
export class Crop {
  gardenId: number;
  cropId: number;
  cropName: string;
  plantName: string;
  beginDate: Date;
  endDate?: Date;
  notes: string;
  cropActivities: CropActivity[];
}
