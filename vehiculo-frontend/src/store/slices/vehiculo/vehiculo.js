import { createSlice } from "@reduxjs/toolkit";

const sliceName = "vehiculo";

const initialState = {
  isFetchingData: false,
  data: [],
  errorMsg: "",
};

const vehiculoSlice = createSlice({
  name: sliceName,
  initialState,
  reducers: {
    vehiculoRequestData(state, action) {},
    vehiculoIsFetching(state, action) {
      state.isFetchingData = action.payload;
    },
    vehiculoRequestError(state, action) {
      state.isFetchingData = false;
      state.errorMsg = action.payload;
    },
    vehiculoRequestDataSuccess(state, action) {
      state.isFetchingData = false;
      state.data = action.payload.data;
    },
    vehiculoRequestCreate(state, action) {
      state.isFetchingData = true;
    },
    vehiculoRequestCreateSuccess(state, action) {
      state.data = action.payload;
      state.isFetchingData = false;
    },
    vehiculoRequestDelete(state) {
      state.isFetchingData = true;
    },
    vehiculoRequestDeleteSuccess(state, action) {
      state.isFetchingData = false;
    },
    vehiculoRequestUpdate(state) {
      state.isFetchingData = true;
    },
    vehiculoRequestUpdateSuccess(state, action) {
      state.isFetchingData = false;
    },
  },
});

const { actions, reducer } = vehiculoSlice;

export const {
  vehiculoRequestData,
  vehiculoIsFetching,
  vehiculoRequestError,
  vehiculoRequestDataSuccess,
  vehiculoRequestCreate,
  vehiculoRequestCreateSuccess,
  vehiculoRequestDelete,
  vehiculoRequestDeleteSuccess,
  vehiculoRequestUpdate,
  vehiculoRequestUpdateSuccess,
} = actions;

export default reducer;
