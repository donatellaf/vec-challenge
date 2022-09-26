import { createSlice } from "@reduxjs/toolkit";

const sliceName = "tipoVehiculo";

const initialState = {
  isFetchingData: false,
  data: [],
  errorMsg: "",
};

const tipoVehiculoSlice = createSlice({
  name: sliceName,
  initialState,
  reducers: {
    tipoVehiculoRequestData(state, action) {},
    tipoVehiculoIsFetching(state, action) {
      state.isFetchingData = action.payload;
    },
    tipoVehiculoRequestError(state, action) {
      state.isFetchingData = false;
      state.errorMsg = action.payload;
    },
    tipoVehiculoRequestDataSuccess(state, action) {
      state.isFetchingData = false;
      state.data = action.payload.data;
    },
  },
});

const { actions, reducer } = tipoVehiculoSlice;

export const {
  tipoVehiculoRequestData,
  tipoVehiculoIsFetching,
  tipoVehiculoRequestError,
  tipoVehiculoRequestDataSuccess,
} = actions;

export default reducer;
