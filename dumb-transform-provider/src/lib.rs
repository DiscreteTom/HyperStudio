#![allow(non_snake_case)]

/// enabled: bool, x: f32, y: f32, z: f32
static mut POS_DATA: [u8; 13] = [0; 13];
/// enabled: bool, x: f32, y: f32, z: f32, w: f32
static mut ROT_DATA: [u8; 17] = [0; 17];

#[no_mangle]
pub extern "C" fn TP_Init() {}

#[no_mangle]
pub extern "C" fn TP_Shutdown() {}

#[no_mangle]
pub unsafe extern "C" fn TP_GetPosition() -> *mut [u8; 13] {
  &mut POS_DATA // position is disabled
}
#[no_mangle]
pub unsafe extern "C" fn TP_GetRotation() -> *mut [u8; 17] {
  &mut ROT_DATA // rotation is disabled
}
