/// enabled: bool, x: f32, y: f32, z: f32
static mut POS_DATA: [u8; 13] = [0; 13];
/// enabled: bool, x: f32, y: f32, z: f32, w: f32
static mut ROT_DATA: [u8; 17] = [0; 17];

pub fn init() {}

pub fn shutdown() {}

pub unsafe fn get_position() -> *mut [u8; 13] {
  &mut POS_DATA // position is disabled
}

pub unsafe fn get_rotation() -> *mut [u8; 17] {
  &mut ROT_DATA // rotation is disabled
}
