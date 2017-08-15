﻿Imports LibOptimization2.Optimization

Namespace BenchmarkFunction
    ''' <summary>
    ''' Benchmark function
    ''' Ackley's function
    ''' </summary>
    ''' <remarks>
    ''' Minimum:
    '''  F(0,...,0) = 0
    ''' Range:
    '''  -32.768 to 32.768
    ''' Referrence:
    ''' 小林重信, "実数値GAのフロンティア"，人工知能学会誌 Vol. 24, No. 1, pp.147-162 (2009)
    ''' </remarks>
    Public Class clsBenchAckley : Inherits absObjectiveFunction
        Private dimension As Integer = 0

        ''' <summary>
        ''' Default constructor
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New(ByVal ai_dim As Integer)
            dimension = ai_dim
        End Sub

        ''' <summary>
        ''' Target Function
        ''' </summary>
        ''' <param name="ai_var"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function F(ByVal ai_var As List(Of Double)) As Double
            If ai_var Is Nothing Then
                Return 0
            End If

            If dimension <> ai_var.Count Then
                Return 0
            End If

            Dim a As Double = 0.0
            Dim b As Double = 0.0
            For i As Integer = 0 To dimension - 1
                a += ai_var(i) ^ 2
                b += Math.Cos(2 * Math.PI * ai_var(i))
            Next
            Dim ret As Double = 20 - 20 * Math.Exp(-0.2 * Math.Sqrt((1 / dimension) * a)) + Math.E - Math.Exp((1 / dimension) * b)

            Return ret
        End Function

        Public Overrides Function Gradient(ByVal ai_var As List(Of Double)) As List(Of Double)
            Throw New NotImplementedException
        End Function

        Public Overrides Function Hessian(ByVal ai_var As List(Of Double)) As List(Of List(Of Double))
            Throw New NotImplementedException
        End Function

        Public Overrides ReadOnly Property NumberOfVariable As Integer
            Get
                Return dimension
            End Get
        End Property
    End Class

End Namespace
