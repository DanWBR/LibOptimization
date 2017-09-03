﻿Imports LibOptimization.Optimization

Namespace BenchmarkFunction
    ''' <summary>
    ''' Benchmark function
    ''' Rosenblock function(Banana function)
    ''' </summary>
    ''' <remarks>
    ''' Minimum:
    '''  F(0,...,0) = 0
    ''' </remarks>
    Public Class BenchRosenblock : Inherits absObjectiveFunction
        Private dimension As Integer = 0

        ''' <summary>
        ''' Default constructor
        ''' </summary>
        ''' <param name="ai_dim">Set dimension</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal ai_dim As Integer)
            If ai_dim <= 1 Then
                Throw New NotImplementedException
            End If
            dimension = ai_dim
        End Sub

        ''' <summary>
        ''' Target Function
        ''' </summary>
        ''' <param name="x"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function F(ByVal x As List(Of Double)) As Double
            If x Is Nothing Then
                Return 0
            End If

            If dimension <> x.Count Then
                Return 0
            End If

            Dim ret As Double = 0.0
            For i As Integer = 0 To dimension - 2
                ret += 100 * (x(i + 1) - x(i) ^ 2) ^ 2 + (x(i) - 1) ^ 2
            Next

            Return ret
        End Function

        Public Overrides Function Gradient(ByVal x As List(Of Double)) As List(Of Double)
            Dim gradVec As New List(Of Double)

            'i0
            Dim grad As Double = 0
            grad = -400 * x(0) * (x(0) - x(1) ^ 2) - 2 * (x(0) - 1)
            gradVec.Add(grad)

            'i1 ~ in-1
            For i As Integer = 1 To dimension - 2
                grad = -400 * x(i) * (x(i + 1) - x(i) ^ 2) + 200 * (x(i) - x(i - 1) ^ 2) - 2
                gradVec.Add(grad)
            Next

            'in
            grad = 200 * (x(dimension - 1) - x(dimension - 2) ^ 2)
            gradVec.Add(grad)

            Return gradVec
        End Function

        Public Overrides Function Hessian(ByVal x As List(Of Double)) As List(Of List(Of Double))
            Dim hesse As New List(Of List(Of Double))
            Dim tempVect(dimension - 1) As Double
            For i As Integer = 0 To dimension - 1
                hesse.Add(New List(Of Double)(tempVect))
            Next

            If dimension = 2 Then
                For i As Integer = 0 To dimension - 1
                    For j As Integer = 0 To dimension - 1
                        If i = j Then
                            If i <> dimension - 1 Then
                                hesse(i)(j) = -400 * (x(i + 1) - x(i) ^ 2) + 800 * x(i) ^ 2 - 2
                            Else
                                hesse(i)(j) = 200
                            End If
                        Else
                            hesse(i)(j) = -400 * x(0)
                        End If
                    Next
                Next
            Else
                For i As Integer = 0 To dimension - 1
                    For j As Integer = 0 To dimension - 1
                        If i = j Then
                            If i = 0 Then
                                hesse(i)(j) = -400 * (x(i + 1) - x(i) ^ 2) + 800 * x(i) ^ 2 - 2
                            ElseIf i = dimension - 1 Then
                                hesse(i)(j) = 200
                            Else
                                hesse(i)(j) = -400 * (x(i + 1) - x(i) ^ 2) + 800 * x(i) ^ 2 + 198
                            End If
                        End If
                        If i = j - 1 Then
                            hesse(i)(j) = -400 * x(i)
                        End If
                        If i - 1 = j Then
                            hesse(i)(j) = -400 * x(j)
                        End If
                    Next
                Next
            End If

            Return hesse
        End Function

        Public Overrides Function NumberOfVariable() As Integer
            Return dimension
        End Function
    End Class

End Namespace
