Public Class ExtTreeNode
    Inherits TreeNode

    Private ID_value As Long
    Private Deleted_value As Boolean
    Private CanRestore_value As Boolean
    Private NodeNum_value As Long
    Private NodeID_value As String
    Private Level9999ID_value As Integer
    Private ItemType_value As String
    Private ItemActive_value As Boolean
    Private ImageID_value As Integer
    Private ImageExpandedID_value As Integer
    Private Level9999Name_value As String
    Private ReportName_value As String
    Private ReportCaption_value As String
    Private ReportNumber_value As String
    Private ReportTimeout_value As Integer
    Private ReportMaxDays_value As Long
    Private ReportMaxReps_value As Long
    Private ReportTitleLine1_value As String
    Private ReportTitleLine2_value As String
    Private ReportCtlViewReport_value As String
    Private ReportCtlHelp_value As String
    Private ReportCtlDateRange_value As String
    Private ReportCtlSendTo_value As String
    Private ReportCtlRegions_value As String
    Private ReportCtlDistricts_value As String
    Private ReportCtlFieldReps_value As String
    Private ReportCtlDispMins_value As String
    Private ReportCtlDispA2Mins_value As String
    Private ReportCtlDispPerfGoals_value As String
    Private ReportCtlViewSummaries_value As String
    Private ReportCtlDispatchDetailFormat_value As String
    Private ReportCtlMonthYear_value As String
    Private ReportCtlYear_value As String
    Private ReportCtlDTAROptions_value As String
    Private ReportCtlNoParameters_value As String
    Private ReportCtlOvertime_value As String
    Private ReportCtlHideFieldCodes_value As String
    Private ReportCtlSections_value As String
    Private ReportCtlOrderTypes_value As String
    Private PrefDateFormat_value As String
    Private PrefLocations_value As String
    Private posCtlDateRange_value As String
    Private posCtlRegions_value As String
    Private posCtlDistricts_value As String
    Private posCtlFieldReps_value As String
    Private posCtlDispatchMins_value As String
    Private posCtlDispatchA2Mins_value As String
    Private posCtlDispPerfGoals_value As String
    Private posCtlViewSummaries_value As String
    Private posDispDetailFormat_value As String
    Private posCtlMonthYear_value As String
    Private posCtlYear_value As String
    Private posCtlDTAROptions_value As String
    Private posCtlNoParameters_value As String
    Private posCtlOvertime_value As String
    Private posCtlHideFieldCodes_value As String
    Private posCtlSections_value As String
    Private posCtlOrderTypes_value As String
    Private posPrefDateFormat_value As String
    Private posPrefLocations_value As String
    Private ParameterPanelBottom_value As Integer
    Private posPMCTypes_value As String
    Private posShifts_value As String
    Private posClassifications_value As String
    Private posRouteTypes_value As String
    Private posActivityTypes_value As String
    Private posBusinessUnits_value As String
    Private posRepeatVisitRecurrenceDays_value As String
    Private ReportFilename_value As String
    Private CommandString_value As String
    Private HelpFile_value As String
    Private NewReportID_value As Integer
    Private PosDepartments_value As String
    Private PosMaxDispatchTransactionMinutes_value As String
    Private SecurityLevel_value As Integer
    Private PosDivisions_value As String
    Private PosOrganizations_value As String
    Private PosLocations_value As String
    Private SchedulingEnabled_value As Boolean

    Public Property ID() As Long
        Get
            Return ID_value
        End Get
        Set(ByVal value As Long)
            ID_value = value
        End Set
    End Property

    Public Property Deleted() As Boolean
        Get
            Return Deleted_value
        End Get
        Set(ByVal value As Boolean)
            Deleted_value = value
        End Set
    End Property

    Public Property CanRestore() As Boolean
        Get
            Return CanRestore_value
        End Get
        Set(ByVal value As Boolean)
            CanRestore_value = value
        End Set
    End Property

    Public Property NodeNum() As Long
        Get
            Return NodeNum_value
        End Get
        Set(ByVal value As Long)
            NodeNum_value = value
        End Set
    End Property

    Public Property NodeID() As String
        Get
            Return NodeID_value
        End Get
        Set(ByVal value As String)
            NodeID_value = value
        End Set
    End Property

    Public Property Level9999ID() As Integer
        Get
            Return Level9999ID_value
        End Get
        Set(ByVal value As Integer)
            Level9999ID_value = value
        End Set
    End Property

    Public Property ItemType() As String
        Get
            Return ItemType_value
        End Get
        Set(ByVal value As String)
            ItemType_value = value
        End Set
    End Property

    Public Property ItemActive() As Boolean
        Get
            Return ItemActive_value
        End Get
        Set(ByVal value As Boolean)
            ItemActive_value = value
        End Set
    End Property

    Public Property ImageID() As Integer
        Get
            Return ImageID_value
        End Get
        Set(ByVal value As Integer)
            ImageID_value = value
        End Set
    End Property

    Public Property ImageExpandedID() As Integer
        Get
            Return ImageExpandedID_value
        End Get
        Set(ByVal value As Integer)
            ImageExpandedID_value = value
        End Set
    End Property

    Public Property Level9999Name() As String
        Get
            Return Level9999Name_value
        End Get
        Set(ByVal value As String)
            Level9999Name_value = value
        End Set
    End Property

    Public Property ReportName() As String
        Get
            Return ReportName_value
        End Get
        Set(ByVal value As String)
            ReportName_value = value
        End Set
    End Property

    Public Property ReportCaption() As String
        Get
            Return ReportCaption_value
        End Get
        Set(ByVal value As String)
            ReportCaption_value = value
        End Set
    End Property

    Public Property ReportNumber() As String
        Get
            Return ReportNumber_value
        End Get
        Set(ByVal value As String)
            ReportNumber_value = value
        End Set
    End Property

    Public Property ReportTimeout() As Integer
        Get
            Return ReportTimeout_value
        End Get
        Set(ByVal value As Integer)
            ReportTimeout_value = value
        End Set
    End Property

    Public Property ReportMaxDays() As Long
        Get
            Return ReportMaxDays_value
        End Get
        Set(ByVal value As Long)
            ReportMaxDays_value = value
        End Set
    End Property

    Public Property ReportMaxReps() As Long
        Get
            Return ReportMaxReps_value
        End Get
        Set(ByVal value As Long)
            ReportMaxReps_value = value
        End Set
    End Property

    Public Property ReportTitleLine1() As String
        Get
            Return ReportTitleLine1_value
        End Get
        Set(ByVal value As String)
            ReportTitleLine1_value = value
        End Set
    End Property

    Public Property ReportTitleLine2() As String
        Get
            Return ReportTitleLine2_value
        End Get
        Set(ByVal value As String)
            ReportTitleLine2_value = value
        End Set
    End Property

    Public Property ReportCtlViewReport() As String
        Get
            Return ReportCtlViewReport_value
        End Get
        Set(ByVal value As String)
            ReportCtlViewReport_value = value
        End Set
    End Property

    Public Property ReportCtlHelp() As String
        Get
            Return ReportCtlHelp_value
        End Get
        Set(ByVal value As String)
            ReportCtlHelp_value = value
        End Set
    End Property

    Public Property ReportCtlDateRange() As String
        Get
            Return ReportCtlDateRange_value
        End Get
        Set(ByVal value As String)
            ReportCtlDateRange_value = value
        End Set
    End Property

    Public Property ReportCtlSendTo() As String
        Get
            Return ReportCtlSendTo_value
        End Get
        Set(ByVal value As String)
            ReportCtlSendTo_value = value
        End Set
    End Property

    Public Property ReportCtlRegions() As String
        Get
            Return ReportCtlRegions_value
        End Get
        Set(ByVal value As String)
            ReportCtlRegions_value = value
        End Set
    End Property

    Public Property ReportCtlDistricts() As String
        Get
            Return ReportCtlDistricts_value
        End Get
        Set(ByVal value As String)
            ReportCtlDistricts_value = value
        End Set
    End Property

    Public Property ReportCtlFieldReps() As String
        Get
            Return ReportCtlFieldReps_value
        End Get
        Set(ByVal value As String)
            ReportCtlFieldReps_value = value
        End Set
    End Property

    Public Property ReportCtlDispMins() As String
        Get
            Return ReportCtlDispMins_value
        End Get
        Set(ByVal value As String)
            ReportCtlDispMins_value = value
        End Set
    End Property

    Public Property ReportCtlDispA2Mins() As String
        Get
            Return ReportCtlDispA2Mins_value
        End Get
        Set(ByVal value As String)
            ReportCtlDispA2Mins_value = value
        End Set
    End Property

    Public Property ReportCtlDispPerfGoals() As String
        Get
            Return ReportCtlDispPerfGoals_value
        End Get
        Set(ByVal value As String)
            ReportCtlDispPerfGoals_value = value
        End Set
    End Property

    Public Property ReportCtlViewSummaries() As String
        Get
            Return ReportCtlViewSummaries_value
        End Get
        Set(ByVal value As String)
            ReportCtlViewSummaries_value = value
        End Set
    End Property

    Public Property ReportCtlDispatchDetailFormat() As String
        Get
            Return ReportCtlDispatchDetailFormat_value
        End Get
        Set(ByVal value As String)
            ReportCtlDispatchDetailFormat_value = value
        End Set
    End Property

    Public Property ReportCtlMonthYear() As String
        Get
            Return ReportCtlMonthYear_value
        End Get
        Set(ByVal value As String)
            ReportCtlMonthYear_value = value
        End Set
    End Property

    Public Property ReportCtlYear() As String
        Get
            Return ReportCtlYear_value
        End Get
        Set(ByVal value As String)
            ReportCtlYear_value = value
        End Set
    End Property

    Public Property ReportCtlDTAROptions() As String
        Get
            Return ReportCtlDTAROptions_value
        End Get
        Set(ByVal value As String)
            ReportCtlDTAROptions_value = value
        End Set
    End Property

    Public Property ReportCtlNoParameters() As String
        Get
            Return ReportCtlNoParameters_value
        End Get
        Set(ByVal value As String)
            ReportCtlNoParameters_value = value
        End Set
    End Property

    Public Property ReportCtlOvertime() As String
        Get
            Return ReportCtlOvertime_value
        End Get
        Set(ByVal value As String)
            ReportCtlOvertime_value = value
        End Set
    End Property

    Public Property ReportCtlHideFieldCodes() As String
        Get
            Return ReportCtlHideFieldCodes_value
        End Get
        Set(ByVal value As String)
            ReportCtlHideFieldCodes_value = value
        End Set
    End Property

    Public Property ReportCtlSections() As String
        Get
            Return ReportCtlSections_value
        End Get
        Set(ByVal value As String)
            ReportCtlSections_value = value
        End Set
    End Property

    Public Property ReportCtlOrderTypes() As String
        Get
            Return ReportCtlOrderTypes_value
        End Get
        Set(ByVal value As String)
            ReportCtlOrderTypes_value = value
        End Set
    End Property

    Public Property PrefDateFormat() As String
        Get
            Return PrefDateFormat_value
        End Get
        Set(ByVal value As String)
            PrefDateFormat_value = value
        End Set
    End Property

    Public Property PrefLocations() As String
        Get
            Return PrefLocations_value
        End Get
        Set(ByVal value As String)
            PrefLocations_value = value
        End Set
    End Property

    Public Property posCtlDateRange() As String
        Get
            Return posCtlDateRange_value
        End Get
        Set(ByVal value As String)
            posCtlDateRange_value = value
        End Set
    End Property

    Public Property posCtlRegions() As String
        Get
            Return posCtlRegions_value
        End Get
        Set(ByVal value As String)
            posCtlRegions_value = value
        End Set
    End Property

    Public Property posCtlDistricts() As String
        Get
            Return posCtlDistricts_value
        End Get
        Set(ByVal value As String)
            posCtlDistricts_value = value
        End Set
    End Property

    Public Property posCtlFieldReps() As String
        Get
            Return posCtlFieldReps_value
        End Get
        Set(ByVal value As String)
            posCtlFieldReps_value = value
        End Set
    End Property

    Public Property posCtlDispatchMins() As String
        Get
            Return posCtlDispatchMins_value
        End Get
        Set(ByVal value As String)
            posCtlDispatchMins_value = value
        End Set
    End Property

    Public Property posCtlDispatchA2Mins() As String
        Get
            Return posCtlDispatchA2Mins_value
        End Get
        Set(ByVal value As String)
            posCtlDispatchA2Mins_value = value
        End Set
    End Property

    Public Property posCtlDispPerfGoals() As String
        Get
            Return posCtlDispPerfGoals_value
        End Get
        Set(ByVal value As String)
            posCtlDispPerfGoals_value = value
        End Set
    End Property

    Public Property posCtlViewSummaries() As String
        Get
            Return posCtlViewSummaries_value
        End Get
        Set(ByVal value As String)
            posCtlViewSummaries_value = value
        End Set
    End Property

    Public Property posDispDetailFormat() As String
        Get
            Return posDispDetailFormat_value
        End Get
        Set(ByVal value As String)
            posDispDetailFormat_value = value
        End Set
    End Property

    Public Property posCtlMonthYear() As String
        Get
            Return posCtlMonthYear_value
        End Get
        Set(ByVal value As String)
            posCtlMonthYear_value = value
        End Set
    End Property

    Public Property posCtlYear() As String
        Get
            Return posCtlYear_value
        End Get
        Set(ByVal value As String)
            posCtlYear_value = value
        End Set
    End Property

    Public Property posCtlDTAROptions() As String
        Get
            Return posCtlDTAROptions_value
        End Get
        Set(ByVal value As String)
            posCtlDTAROptions_value = value
        End Set
    End Property

    Public Property posCtlNoParameters() As String
        Get
            Return posCtlNoParameters_value
        End Get
        Set(ByVal value As String)
            posCtlNoParameters_value = value
        End Set
    End Property

    Public Property posCtlOvertime() As String
        Get
            Return posCtlOvertime_value
        End Get
        Set(ByVal value As String)
            posCtlOvertime_value = value
        End Set
    End Property

    Public Property posCtlHideFieldCodes() As String
        Get
            Return posCtlHideFieldCodes_value
        End Get
        Set(ByVal value As String)
            posCtlHideFieldCodes_value = value
        End Set
    End Property

    Public Property posCtlSections() As String
        Get
            Return posCtlSections_value
        End Get
        Set(ByVal value As String)
            posCtlSections_value = value
        End Set
    End Property

    Public Property posCtlOrderTypes() As String
        Get
            Return posCtlOrderTypes_value
        End Get
        Set(ByVal value As String)
            posCtlOrderTypes_value = value
        End Set
    End Property

    Public Property posPrefDateFormat() As String
        Get
            Return posPrefDateFormat_value
        End Get
        Set(ByVal value As String)
            posPrefDateFormat_value = value
        End Set
    End Property

    Public Property posPrefLocations() As String
        Get
            Return posPrefLocations_value
        End Get
        Set(ByVal value As String)
            posPrefLocations_value = value
        End Set
    End Property

    Public Property ParameterPanelBottom() As Integer
        Get
            Return ParameterPanelBottom_value
        End Get
        Set(ByVal value As Integer)
            ParameterPanelBottom_value = value
        End Set
    End Property

    Public Property posPMCTypes() As String
        Get
            Return posPMCTypes_value
        End Get
        Set(ByVal value As String)
            posPMCTypes_value = value
        End Set
    End Property

    Public Property posShifts() As String
        Get
            Return posShifts_value
        End Get
        Set(ByVal value As String)
            posShifts_value = value
        End Set
    End Property

    Public Property posClassifications() As String
        Get
            Return posClassifications_value
        End Get
        Set(ByVal value As String)
            posClassifications_value = value
        End Set
    End Property

    Public Property posRouteTypes() As String
        Get
            Return posRouteTypes_value
        End Get
        Set(ByVal value As String)
            posRouteTypes_value = value
        End Set
    End Property

    Public Property posActivityTypes() As String
        Get
            Return posActivityTypes_value
        End Get
        Set(ByVal value As String)
            posActivityTypes_value = value
        End Set
    End Property

    Public Property posBusinessUnits() As String
        Get
            Return posBusinessUnits_value
        End Get
        Set(ByVal value As String)
            posBusinessUnits_value = value
        End Set
    End Property

    Public Property posRepeatVisitRecurrenceDays() As String
        Get
            Return posRepeatVisitRecurrenceDays_value
        End Get
        Set(ByVal value As String)
            posRepeatVisitRecurrenceDays_value = value
        End Set
    End Property

    Public Property ReportFilename() As String
        Get
            Return ReportFilename_value
        End Get
        Set(ByVal value As String)
            ReportFilename_value = value
        End Set
    End Property

    Public Property CommandString() As String
        Get
            Return CommandString_value
        End Get
        Set(ByVal value As String)
            CommandString_value = value
        End Set
    End Property

    Public Property HelpFile() As String
        Get
            Return HelpFile_value
        End Get
        Set(ByVal value As String)
            HelpFile_value = value
        End Set
    End Property

    Public Property NewReportID() As Integer
        Get
            Return NewReportID_value
        End Get
        Set(ByVal value As Integer)
            NewReportID_value = value
        End Set
    End Property

    Public Property PosDepartments() As String
        Get
            Return PosDepartments_value
        End Get
        Set(ByVal value As String)
            PosDepartments_value = value
        End Set
    End Property

    Public Property PosMaxDispatchTransactionMinutes() As String
        Get
            Return PosMaxDispatchTransactionMinutes_value
        End Get
        Set(ByVal value As String)
            PosMaxDispatchTransactionMinutes_value = value
        End Set
    End Property

    Public Property SecurityLevel() As Integer
        Get
            Return SecurityLevel_value
        End Get
        Set(ByVal value As Integer)
            SecurityLevel_value = value
        End Set
    End Property

    Public Property PosDivisions() As String
        Get
            Return PosDivisions_value
        End Get
        Set(ByVal value As String)
            PosDivisions_value = value
        End Set
    End Property

    Public Property PosOrganizations() As String
        Get
            Return PosOrganizations_value
        End Get
        Set(ByVal value As String)
            PosOrganizations_value = value
        End Set
    End Property

    Public Property PosLocations() As String
        Get
            Return PosLocations_value
        End Get
        Set(ByVal value As String)
            PosLocations_value = value
        End Set
    End Property

    Public Property SchedulingEnabled() As Boolean
        Get
            Return SchedulingEnabled_value
        End Get
        Set(ByVal value As Boolean)
            SchedulingEnabled_value = value
        End Set
    End Property
End Class
