﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metaclassification.Data
{
    public enum Titles {
        szemely = 0,
        eredetiseg = 1,
        Accent_Angle_0 = 130,
        Accent_Angle_1 = 136,
        Accent_Angle_2 = 142,
        Accent_Length_0 = 131,
        Accent_Length_1 = 137,
        Accent_Length_2 = 143,
        Accent_X_0 = 126,
        Accent_X_1 = 132,
        Accent_X_2 = 138,
        Accent_X2_0 = 128,
        Accent_X2_1 = 134,
        Accent_X2_2 = 140,
        Accent_Y_0 = 127,
        Accent_Y_1 = 133,
        Accent_Y_2 = 139,
        Accent_Y2_0 = 129,
        Accent_Y2_1 = 135,
        Accent_Y2_2 = 141,
        BaseLine_Angle_0 = 6,
        BaseLine_Angle_1 = 12,
        BaseLine_Angle_2 = 18,
        BaseLine_Angle_3 = 24,
        BaseLine_Angle_4 = 30,
        BaseLine_Angle_5 = 36,
        BaseLine_Length_0 = 7,
        BaseLine_Length_1 = 13,
        BaseLine_Length_2 = 19,
        BaseLine_Length_3 = 25,
        BaseLine_Length_4 = 31,
        BaseLine_Length_5 = 37,
        BaseLine_X_0 = 2,
        BaseLine_X_1 = 8,
        BaseLine_X_2 = 14,
        BaseLine_X_3 = 20,
        BaseLine_X_4 = 26,
        BaseLine_X_5 = 32,
        BaseLine_X2_0 = 4,
        BaseLine_X2_1 = 10,
        BaseLine_X2_2 = 16,
        BaseLine_X2_3 = 22,
        BaseLine_X2_4 = 28,
        BaseLine_X2_5 = 34,
        BaseLine_Y_0 = 3,
        BaseLine_Y_1 = 9,
        BaseLine_Y_2 = 15,
        BaseLine_Y_3 = 21,
        BaseLine_Y_4 = 27,
        BaseLine_Y_5 = 33,
        BaseLine_Y2_0 = 5,
        BaseLine_Y2_1 = 11,
        BaseLine_Y2_2 = 17,
        BaseLine_Y2_3 = 23,
        BaseLine_Y2_4 = 29,
        BaseLine_Y2_5 = 35,
        Global_features_AspectRatio_0 = 146,
        Global_features_Height_0 = 145,
        Global_features_TrimmedAspectRatio_0 = 149,
        Global_features_TrimmedHeight_0 = 148,
        Global_features_TrimmedWidth_0 = 147,
        Global_features_Width_0 = 144,
        Loop_Area_0 = 43,
        Loop_Area_1 = 60,
        Loop_Area_2 = 77,
        Loop_Area_3 = 94,
        Loop_Area_4 = 111,
        Loop_AspectRatio_0 = 51,
        Loop_AspectRatio_1 = 68,
        Loop_AspectRatio_2 = 85,
        Loop_AspectRatio_3 = 102,
        Loop_AspectRatio_4 = 119,
        Loop_BoundingCircleRadius_0 = 42,
        Loop_BoundingCircleRadius_1 = 59,
        Loop_BoundingCircleRadius_2 = 76,
        Loop_BoundingCircleRadius_3 = 93,
        Loop_BoundingCircleRadius_4 = 110,
        Loop_Compactness_0 = 47,
        Loop_Compactness_1 = 64,
        Loop_Compactness_2 = 81,
        Loop_Compactness_3 = 98,
        Loop_Compactness_4 = 115,
        Loop_Convexity_0 = 50,
        Loop_Convexity_1 = 67,
        Loop_Convexity_2 = 84,
        Loop_Convexity_3 = 101,
        Loop_Convexity_4 = 118,
        Loop_Extent_0 = 48,
        Loop_Extent_1 = 65,
        Loop_Extent_2 = 82,
        Loop_Extent_3 = 99,
        Loop_Extent_4 = 116,
        Loop_Formfactor_0 = 45,
        Loop_Formfactor_1 = 62,
        Loop_Formfactor_2 = 79,
        Loop_Formfactor_3 = 96,
        Loop_Formfactor_4 = 113,
        Loop_InscribedDiameter_0 = 41,
        Loop_InscribedDiameter_1 = 58,
        Loop_InscribedDiameter_2 = 75,
        Loop_InscribedDiameter_3 = 92,
        Loop_InscribedDiameter_4 = 109,
        Loop_MaximumDiameter_0 = 39,
        Loop_MaximumDiameter_1 = 56,
        Loop_MaximumDiameter_2 = 73,
        Loop_MaximumDiameter_3 = 90,
        Loop_MaximumDiameter_4 = 107,
        Loop_MaximumDiameterAngle_0 = 40,
        Loop_MaximumDiameterAngle_1 = 57,
        Loop_MaximumDiameterAngle_2 = 74,
        Loop_MaximumDiameterAngle_3 = 91,
        Loop_MaximumDiameterAngle_4 = 108,
        Loop_ModificationRatio_0 = 52,
        Loop_ModificationRatio_1 = 69,
        Loop_ModificationRatio_2 = 86,
        Loop_ModificationRatio_3 = 103,
        Loop_ModificationRatio_4 = 120,
        Loop_MomentAxisAngle_0 = 44,
        Loop_MomentAxisAngle_1 = 61,
        Loop_MomentAxisAngle_2 = 78,
        Loop_MomentAxisAngle_3 = 95,
        Loop_MomentAxisAngle_4 = 112,
        Loop_Perimeter_0 = 38,
        Loop_Perimeter_1 = 55,
        Loop_Perimeter_2 = 72,
        Loop_Perimeter_3 = 89,
        Loop_Perimeter_4 = 106,
        Loop_Roundness_0 = 46,
        Loop_Roundness_1 = 63,
        Loop_Roundness_2 = 80,
        Loop_Roundness_3 = 97,
        Loop_Roundness_4 = 114,
        Loop_Solidity_0 = 49,
        Loop_Solidity_1 = 66,
        Loop_Solidity_2 = 83,
        Loop_Solidity_3 = 100,
        Loop_Solidity_4 = 117,
        Loop_X_0 = 53,
        Loop_X_1 = 70,
        Loop_X_2 = 87,
        Loop_X_3 = 104,
        Loop_X_4 = 121,
        Loop_Y_0 = 54,
        Loop_Y_1 = 71,
        Loop_Y_2 = 88,
        Loop_Y_3 = 105,
        Loop_Y_4 = 122,
        Shape_AreaPixels_0 = 123,
        Shape_ConvexHullPixels_0 = 124,
        Shape_TextPixels_0 = 125
    };

}