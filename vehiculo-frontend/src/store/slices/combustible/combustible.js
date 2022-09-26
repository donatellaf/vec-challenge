import { createSlice } from "@reduxjs/toolkit";

const sliceName = "combustible";

const initialState = {
  isFetchingData: false,
  data: [],
  errorMsg: "",
};

const combustibleSlice = createSlice({
  name: sliceName,
  initialState,
  reducers: {
    combustibleRequestData(state, action) {},
    combustibleIsFetching(state, action) {
      state.isFetchingData = action.payload;
    },
    combustibleRequestError(state, action) {
      state.isFetchingData = false;
      state.errorMsg = action.payload;
    },
    combustibleRequestDataSuccess(state, action) {
      state.isFetchingData = false;
      state.data = action.payload.data;
    },
  },
});

const { actions, reducer } = combustibleSlice;

export const {
  combustibleRequestData,
  combustibleIsFetching,
  combustibleRequestError,
  combustibleRequestDataSuccess,
} = actions;

export default reducer;
