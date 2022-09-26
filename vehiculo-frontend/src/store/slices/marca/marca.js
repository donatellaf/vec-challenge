import { createSlice } from "@reduxjs/toolkit";

const sliceName = "marca";

const initialState = {
  isFetchingData: false,
  data: [],
  errorMsg: "",
};

const marcaSlice = createSlice({
  name: sliceName,
  initialState,
  reducers: {
    marcaRequestData(state, action) {},
    marcaIsFetching(state, action) {
      state.isFetchingData = action.payload;
    },
    marcaRequestError(state, action) {
      state.isFetchingData = false;
      state.errorMsg = action.payload;
    },
    marcaRequestDataSuccess(state, action) {
      state.isFetchingData = false;
      state.data = action.payload.data;
    },
  },
});

const { actions, reducer } = marcaSlice;

export const {
  marcaRequestData,
  marcaIsFetching,
  marcaRequestError,
  marcaRequestDataSuccess,
} = actions;

export default reducer;
