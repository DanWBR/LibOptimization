﻿Imports LibOptimization
Imports LibOptimization.Optimization
Imports LibOptimization.Util
Imports LibOptimization.BenchmarkFunction

Module Module1

    Public Class IndexPair
        Implements IComparable
        Public Property Index As Integer = 0
        Public Property Eval As Integer = 0

        ''' <summary>
        ''' Constructor
        ''' </summary>
        Private Sub New()
            'nop
        End Sub

        ''' <summary>
        ''' Constructor
        ''' </summary>
        ''' <param name="ai_index"></param>
        ''' <param name="ai_eval"></param>
        ''' <remarks></remarks>
        Public Sub New(ByVal ai_index As Integer, ByVal ai_eval As Integer)
            Index = ai_index
            Eval = ai_eval
        End Sub

        ''' <summary>
        ''' Compare(ICompareble)
        ''' </summary>
        ''' <param name="ai_obj"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' larger Me than obj is -1. smaller Me than obj is 1.
        ''' Equal is return to Zero
        ''' </remarks>
        Public Function CompareTo(ByVal ai_obj As Object) As Integer Implements System.IComparable.CompareTo
            'Compare
            Dim mineValue As Double = Eval
            Dim compareValue As Double = DirectCast(ai_obj, IndexPair).Eval
            If mineValue = compareValue Then
                Return 0
            ElseIf mineValue < compareValue Then
                Return -1
            Else
                Return 1
            End If
        End Function
    End Class

    Sub Main()
        'Sample code.
        'LibOptimization is numerical optimization algorithm library for .NET Framework.
        'This library will probably simplify the optimization using C# and VB.Net and other .NET Framework language.

        'How to use
        ' 1. You inherit "absObjectiveFunction" class and design objective function.
        ' 2. Choose an optimization method and implement code.
        ' 3. Do optimization!
        ' 4. Get result and evaluate.

        'With Nothing
        '    Dim f = New clsBenchDeJongFunction5()
        '    For i As Integer = -50 To 50 - 1
        '        For j As Integer = -50 To 50 - 1
        '            Dim eval = f.F(New Double() {i, j}.ToList())
        '            Console.Write("{0},", eval)
        '        Next
        '        Console.WriteLine("")
        '    Next
        '    Return
        'End With

        With Nothing
            'Dim optimization As New clsOptRealGAUNDX(New clsBenchSphere(2))
            'optimization.Init()
            'While (optimization.DoIteration(100) = False)
            '    clsUtil.DebugValue(optimization, ai_isOutValue:=False)
            'End While
            'clsUtil.DebugValue(optimization)
        End With

        With Nothing
            'Dim itr As Integer = 999
            'Dim sumTime1 As Long = 0
            'Dim sumTime2 As Long = 0
            'Dim sumTime3 As Long = 0

            'Dim a As New List(Of IndexPair)(100)
            'For j As Integer = 0 To 99
            '    a.Add(New IndexPair(j, clsRandomXorshiftSingleton.GetInstance().Next()))
            'Next

            'For count As Integer = 0 To 99
            '    Dim sw As New Stopwatch()
            '    sw.Reset()
            '    sw.Start()
            '    Dim temp = LibOptimization2.Util.clsUtil.CreateIndexArray(100)
            '    For i As Integer = 0 To itr
            '        LibOptimization2.Util.clsUtil.ShuffleIndex(temp)
            '    Next
            '    sw.Stop()
            '    sumTime1 += sw.ElapsedMilliseconds

            '    sw.Reset()
            '    sw.Start()
            '    For i As Integer = 0 To itr
            '        Dim temp2 = LibOptimization2.Util.clsUtil.RandomPermutaion(100)
            '    Next
            '    sw.Stop()
            '    sumTime2 += sw.ElapsedMilliseconds

            '    sw.Reset()
            '    sw.Start()
            '    For i As Integer = 0 To itr
            '        Dim temp2 = LibOptimization2.Util.clsUtil.RandomPermutaion(100)
            '    Next
            '    sw.Stop()
            '    sumTime2 += sw.ElapsedMilliseconds

            '    sw.Reset()
            '    sw.Start()
            '    For i As Integer = 0 To itr
            '        a.Sort()
            '    Next
            '    sw.Stop()
            '    sumTime3 += sw.ElapsedMilliseconds
            'Next
            'Console.WriteLine("{0}", sumTime1)
            'Console.WriteLine("{0}", sumTime2)
            'Console.WriteLine("{0}", sumTime3)
            'Console.ReadLine()
        End With

        With Nothing
            'Dim sw As New Stopwatch()
            'sw.Reset()
            'sw.Start()
            'For i As Integer = 0 To 4
            '    Dim optimization As New LibOptimization2.Optimization.DerivativeFree.DifferentialEvolution.JADE()
            '    optimization.ObjectiveFunction = New LibOptimization2.BenchmarkFunction.clsBenchRosenblock(10)
            '    optimization.Init()
            '    optimization.DoIteration()
            '    LibOptimization2.Util.clsUtil.DebugValue(optimization.BestResult)
            'Next
            'sw.Stop()
            'Console.WriteLine("{0}", sw.ElapsedMilliseconds)

            'sw.Reset()
            'sw.Start()
            'For i As Integer = 0 To 4
            '    Dim optimization As New LibOptimization2.Optimization.DerivativeFree.DifferentialEvolution.JADE2()
            '    optimization.ObjectiveFunction = New LibOptimization2.BenchmarkFunction.clsBenchRosenblock(10)
            '    optimization.Init()
            '    optimization.DoIteration()
            '    LibOptimization2.Util.clsUtil.DebugValue(optimization.BestResult)
            'Next
            'sw.Stop()
            'Console.WriteLine("{0}", sw.ElapsedMilliseconds)

            'Console.ReadLine()
        End With

        With Nothing
            Dim optimization As New LibOptimization2.Optimization.DerivativeFree.ParticleSwarmOptmization.LDIWPSO()
            optimization.ObjectiveFunction = New LibOptimization2.BenchmarkFunction.clsBenchRosenblock(20)

            'optimization.LowerBounds = New Double() {1, 1}
            'optimization.UpperBounds = New Double() {60, 60}
            'optimization.UseBounds = False
            optimization.Iteration = 10000
            'optimization.WeightMin = 0.1
            'optimization.UseCriterion = False
            'optimization.PopulationSize = 500

            optimization.Init()
            LibOptimization2.Util.Util.DebugValue(optimization.BestResult)
            While (optimization.DoIteration(100) = False)
                LibOptimization2.Util.Util.DebugValue(optimization.BestResult)
                Console.WriteLine("Weight:{0}", optimization.Weight)
            End While
            LibOptimization2.Util.Util.DebugValue(optimization.BestResult)

            Return
        End With

        With Nothing
            For i As Integer = 0 To 9
                Dim optimization As New LibOptimization2.Optimization.DerivativeFree.SimulatedAnnealing()
                optimization.ObjectiveFunction = New LibOptimization2.BenchmarkFunction.clsBenchSphere(2)
                'optimization.ALPHA = 0.2
                optimization.PopulationSize = 100
                optimization.Iteration = 10000
                optimization.InitialValueRange = 20.48
                optimization.LowerBounds = New Double() {1, 1}
                optimization.UpperBounds = New Double() {60, 60}
                optimization.UseBounds = True
                optimization.UseAdaptivePopulationSize = False
                optimization.Init()
                LibOptimization2.Util.Util.DebugValue(optimization.BestResult)
                optimization.DoIteration()
                LibOptimization2.Util.Util.DebugValue(optimization.BestResult)
            Next
        End With

        With Nothing
            Dim optimization As New clsOptDEJADE(New clsBenchTest2())
            optimization.LowerBounds = New Double() {0, 0}
            optimization.UpperBounds = New Double() {5, 5}
            optimization.Init()
            While (optimization.DoIteration(100) = False)
                clsUtil.DebugValue(optimization, ai_isOutValue:=False)
            End While
            clsUtil.DebugValue(optimization)
        End With

        With Nothing
            Dim optimization As New clsOptDEJADE(New clsBenchRosenblock(10))
            optimization.Init()
            clsUtil.DebugValue(optimization)
            While (optimization.DoIteration(100) = False)
                clsUtil.DebugValue(optimization, ai_isOutValue:=False)
            End While
            clsUtil.DebugValue(optimization)
        End With

        'Experiment
        Experiment()

        'how to use liboptimization
        HowtouseLibOptimization()
    End Sub

    Private Sub Experiment()
        With Nothing
            Dim optimization As New clsOptRealGASPX(New clsBenchSphere(2))
            'set inital position and inital value range
            optimization.InitialPosition = {3, 3}
            optimization.InitialValueRange = 0.5
            'limit solution space
            optimization.UpperBounds = {5, 5}
            optimization.LowerBounds = {1, 2}
            optimization.Init()
            clsUtil.DebugValue(optimization)
            While (optimization.DoIteration(50) = False)
                clsUtil.DebugValue(optimization, ai_isOutValue:=False)
            End While
            clsUtil.DebugValue(optimization)
        End With

        With Nothing
            Dim optimization As New clsOptDE(New clsBenchSphere(2))
            'set inital position and inital value range
            optimization.InitialPosition = {3, 3}
            optimization.InitialValueRange = 0.5
            'limit solution space
            optimization.UpperBounds = {5, 5}
            optimization.LowerBounds = {1, 2}
            optimization.Init()
            clsUtil.DebugValue(optimization)
            While (optimization.DoIteration(50) = False)
                clsUtil.DebugValue(optimization, ai_isOutValue:=False)
            End While
            clsUtil.DebugValue(optimization)
        End With
    End Sub

    Private Sub HowtouseLibOptimization()
        'Typical use
        With Nothing
            'Instantiation optimization class and set objective function.
            Dim optimization As New clsOptDE(New clsRosenBlock())
            'Initialize starting value
            optimization.Init()
            ''Do calc
            optimization.DoIteration()
            'Get result. Check recent error.
            If optimization.IsRecentError() = True Then
                Return
            Else
                clsUtil.DebugValue(optimization)
            End If
        End With

        'Set of initial value and the initial position
        'Initial value is generated in the range of 2.5 and 3.5.
        With Nothing
            Dim optimization As New clsOptRealGASPX(New clsBenchSphere(2))
            optimization.InitialPosition = {3, 3}
            optimization.InitialValueRange = 0.5
            optimization.Init()
            While (optimization.DoIteration(5) = False)
                clsUtil.DebugValue(optimization, ai_isOutValue:=False)
            End While
            clsUtil.DebugValue(optimization)
        End With

        'Set initial point.
        '(Not preparation all algorithms.)
        With Nothing
            Dim optimization As New clsOptSteepestDescent(New clsBenchSphere(2))
            optimization.Init(New Double() {-10, 10})
            While (optimization.DoIteration(5) = False)
                clsUtil.DebugValue(optimization)
            End While
            clsUtil.DebugValue(optimization, ai_isOnlyIterationCount:=True)
        End With

        'Set random class and seed.
        With Nothing
            Dim optimization As New clsOptRealGASPX(New clsBenchSphere(1))
            optimization.Random = New clsRandomXorshift(123456) ' or System.Random(123456)
            optimization.Init()
            optimization.DoIteration()
            If optimization.IsRecentError() = True Then
                Return
            Else
                clsUtil.DebugValue(optimization)
            End If
        End With

        'When you want result every 5 times.
        With Nothing
            Dim optimization As New clsOptSteepestDescent(New clsBenchSphere(2))
            optimization.Init()
            While (optimization.DoIteration(5) = False)
                clsUtil.DebugValue(optimization, ai_isOutValue:=False)
            End While
            clsUtil.DebugValue(optimization)
        End With

        'You can use other optimization algorithm.
        With Nothing
            Dim optimization As New clsOptRealGASPX(New clsBenchRastrigin(20))
            optimization.Init()
            clsUtil.DebugValue(optimization)
            While True
                If optimization.DoIteration(10) = True Then
                    Exit While
                End If
                clsUtil.DebugValue(optimization, ai_isOutValue:=False)
            End While
            If optimization.IsRecentError() = True Then
                Return
            End If
            clsUtil.DebugValue(optimization)
        End With

        'Elite Strategy for RGA
        With Nothing
            'De jong Function3
            Dim optimization1 As New Optimization.clsOptRealGASPX(New BenchmarkFunction.clsBenchDeJongFunction3())
            optimization1.Init()
            For i As Integer = 0 To 2
                optimization1.DoIteration()
                clsUtil.DebugValue(optimization1)
                'Carry over to the new iteration.
                optimization1.UseEliteStrategy(0.1)
            Next
            clsUtil.DebugValue(optimization1)

            'De jong Function5
            Dim optimization2 As New Optimization.clsOptRealGASPX(New clsBenchDeJongFunction5())
            optimization2.InitialValueRange = 65.536
            optimization2.ChildrenSize = 100
            optimization2.Init()
            For i As Integer = 0 To 5
                optimization2.DoIteration()
                clsUtil.DebugValue(optimization2, ai_isOutValue:=False)
                optimization2.UseEliteStrategy(0.1)
            Next
            clsUtil.DebugValue(optimization2)
        End With

        'Multi point and MultiThread
        ' - Multipoint avoids Local minimum by preparing many values.
        With Nothing
            'prepare many optimization class.
            Dim multipointNumber As Integer = 30
            Dim listOptimization As New List(Of absOptimization)
            For i As Integer = 0 To multipointNumber - 1
                Dim tempOpt As New clsOptNelderMead(New clsBenchAckley(20))
                tempOpt.Init()
                listOptimization.Add(tempOpt)
            Next

            'using Parallel.ForEach
            Dim lockObj As New Object()
            Dim best As absOptimization = Nothing
            Threading.Tasks.Parallel.ForEach(listOptimization, Sub(opt As absOptimization)
                                                                   opt.DoIteration()
                                                                   'Swap best result
                                                                   SyncLock lockObj
                                                                       If best Is Nothing Then
                                                                           best = opt
                                                                       ElseIf best.Result.Eval > opt.Result.Eval Then
                                                                           best = opt
                                                                       End If
                                                                   End SyncLock
                                                               End Sub)

            'Check Error
            If best.IsRecentError() = True Then
                Return
            Else
                clsUtil.DebugValue(best)
            End If
        End With

        'LeastSquaresMethod 最小二乗法
        With Nothing
            '評価関数
            Dim objectiveFunction = New clsLeastSquaresMethod()
            If objectiveFunction.Init("..\..\..\_sampledata\data.csv") = False Then
                Return
            End If

            '最小化
            Dim opt As New LibOptimization.Optimization.clsOptDE(objectiveFunction)
            opt.Init()
            LibOptimization.Util.clsUtil.DebugValue(opt)
            While (opt.DoIteration(50) = False)
                LibOptimization.Util.clsUtil.DebugValue(opt, ai_isOutValue:=False)
            End While
            LibOptimization.Util.clsUtil.DebugValue(opt)
        End With

        'Constrained optimization for the Heuristic algorithm
        With Nothing
            'You design a constrained function.
            Dim optimization As New clsOptDE(New clsUnconstrainedOptimization)
            optimization.Init()
            optimization.DoIteration()
            If optimization.IsRecentError() = True Then
                Return
            Else
                clsUtil.DebugValue(optimization)
            End If
        End With
    End Sub

    Private Sub CheckOptimization()
        Dim tgtFunction As absObjectiveFunction = New clsBenchSphere(5)
        With Nothing
            Dim DIMENSION = 5
            Dim optimization As absOptimization
            optimization = New clsOptSteepestDescent(tgtFunction)
            optimization.Init()
            optimization.DoIteration()
            clsUtil.DebugValue(optimization, ai_isOutValue:=False)

            optimization = New clsOptNewtonMethod(tgtFunction)
            optimization.Init()
            optimization.DoIteration()
            clsUtil.DebugValue(optimization, ai_isOutValue:=False)

            optimization = New clsOptNelderMead(tgtFunction)
            optimization.Init()
            optimization.DoIteration()
            clsUtil.DebugValue(optimization, ai_isOutValue:=False)

            optimization = New clsOptNelderMeadWiki(tgtFunction)
            optimization.Init()
            optimization.DoIteration()
            clsUtil.DebugValue(optimization, ai_isOutValue:=False)

            optimization = New clsOptPatternSearch(tgtFunction)
            optimization.Init()
            optimization.DoIteration()
            clsUtil.DebugValue(optimization, ai_isOutValue:=False)

            optimization = New clsOptRealGAREX(tgtFunction)
            optimization.Init()
            optimization.DoIteration()
            clsUtil.DebugValue(optimization, ai_isOutValue:=False)

            optimization = New clsOptRealGASPX(tgtFunction)
            optimization.Init()
            optimization.DoIteration()
            clsUtil.DebugValue(optimization, ai_isOutValue:=False)

            optimization = New clsOptPSO(tgtFunction)
            optimization.Init()
            optimization.DoIteration()
            clsUtil.DebugValue(optimization, ai_isOutValue:=False)

            optimization = New clsOptPSOLDIW(tgtFunction)
            optimization.Init()
            optimization.DoIteration()
            clsUtil.DebugValue(optimization, ai_isOutValue:=False)

            optimization = New clsOptPSOChaoticIW(tgtFunction)
            CType(optimization, clsOptPSOChaoticIW).ChaoticMode = clsOptPSOChaoticIW.EnumChaoticInertiaWeightMode.CDIW
            optimization.Init()
            optimization.DoIteration()
            clsUtil.DebugValue(optimization, ai_isOutValue:=False)

            optimization = New clsOptPSOChaoticIW(tgtFunction)
            CType(optimization, clsOptPSOChaoticIW).ChaoticMode = clsOptPSOChaoticIW.EnumChaoticInertiaWeightMode.CRIW
            optimization.Init()
            optimization.DoIteration()
            clsUtil.DebugValue(optimization, ai_isOutValue:=False)

            optimization = New clsOptPSOAIW(tgtFunction)
            optimization.Init()
            optimization.DoIteration()
            clsUtil.DebugValue(optimization, ai_isOutValue:=False)

            optimization = New clsOptDE(tgtFunction)
            optimization.Init()
            optimization.DoIteration()
            clsUtil.DebugValue(optimization, ai_isOutValue:=False)

            optimization = New clsOptSimulatedAnnealing(tgtFunction)
            optimization.Init()
            optimization.DoIteration()
            clsUtil.DebugValue(optimization, ai_isOutValue:=False)
        End With

        Console.WriteLine("-------------")

        tgtFunction = New clsBenchRosenblock(5)
        With Nothing
            Dim DIMENSION = 5
            Dim optimization As absOptimization
            optimization = New clsOptSteepestDescent(tgtFunction)
            optimization.Init()
            optimization.DoIteration()
            clsUtil.DebugValue(optimization, ai_isOutValue:=False)

            optimization = New clsOptNewtonMethod(tgtFunction)
            CType(optimization, clsOptNewtonMethod).ALPHA = 0.0001
            optimization.Init()
            optimization.DoIteration()
            clsUtil.DebugValue(optimization, ai_isOutValue:=False)

            optimization = New clsOptNelderMead(tgtFunction)
            optimization.Init()
            optimization.DoIteration()
            clsUtil.DebugValue(optimization, ai_isOutValue:=False)

            optimization = New clsOptNelderMeadWiki(tgtFunction)
            optimization.Init()
            optimization.DoIteration()
            clsUtil.DebugValue(optimization, ai_isOutValue:=False)

            optimization = New clsOptPatternSearch(tgtFunction)
            optimization.Init()
            optimization.DoIteration()
            clsUtil.DebugValue(optimization, ai_isOutValue:=False)

            optimization = New clsOptRealGAREX(tgtFunction)
            optimization.Init()
            optimization.DoIteration()
            clsUtil.DebugValue(optimization, ai_isOutValue:=False)

            optimization = New clsOptRealGASPX(tgtFunction)
            optimization.Init()
            optimization.DoIteration()
            clsUtil.DebugValue(optimization, ai_isOutValue:=False)

            optimization = New clsOptPSO(tgtFunction)
            optimization.Init()
            optimization.DoIteration()
            clsUtil.DebugValue(optimization, ai_isOutValue:=False)

            optimization = New clsOptPSOLDIW(tgtFunction)
            optimization.Init()
            optimization.DoIteration()
            clsUtil.DebugValue(optimization, ai_isOutValue:=False)

            optimization = New clsOptPSOChaoticIW(tgtFunction)
            CType(optimization, clsOptPSOChaoticIW).ChaoticMode = clsOptPSOChaoticIW.EnumChaoticInertiaWeightMode.CDIW
            optimization.Init()
            optimization.DoIteration()
            clsUtil.DebugValue(optimization, ai_isOutValue:=False)

            optimization = New clsOptPSOChaoticIW(tgtFunction)
            CType(optimization, clsOptPSOChaoticIW).ChaoticMode = clsOptPSOChaoticIW.EnumChaoticInertiaWeightMode.CRIW
            optimization.Init()
            optimization.DoIteration()
            clsUtil.DebugValue(optimization, ai_isOutValue:=False)

            optimization = New clsOptPSOAIW(tgtFunction)
            optimization.Init()
            optimization.DoIteration()
            clsUtil.DebugValue(optimization, ai_isOutValue:=False)

            optimization = New clsOptDE(tgtFunction, clsOptDE.EnumDEStrategyType.DE_rand_1_bin)
            optimization.Init()
            optimization.DoIteration()
            clsUtil.DebugValue(optimization, ai_isOutValue:=False)

            optimization = New clsOptDE(tgtFunction, clsOptDE.EnumDEStrategyType.DE_best_1_bin)
            optimization.Init()
            optimization.DoIteration()
            clsUtil.DebugValue(optimization, ai_isOutValue:=False)

            optimization = New clsOptDE(tgtFunction, clsOptDE.EnumDEStrategyType.DE_rand_2_bin)
            optimization.Init()
            optimization.DoIteration()
            clsUtil.DebugValue(optimization, ai_isOutValue:=False)

            optimization = New clsOptDE(tgtFunction, clsOptDE.EnumDEStrategyType.DE_best_2_bin)
            optimization.Init()
            optimization.DoIteration()
            clsUtil.DebugValue(optimization, ai_isOutValue:=False)

            optimization = New clsOptSimulatedAnnealing(tgtFunction)
            optimization.Init()
            optimization.DoIteration()
            clsUtil.DebugValue(optimization, ai_isOutValue:=False)
        End With
    End Sub

    Private Sub ComparisonHJNR()
        Console.WriteLine("HookeJeeves(PatternSearch) - MovePoint")
        With Nothing
            Dim optimization As New clsOptPatternSearch(New clsBenchRosenblock(2))
            optimization.Init(New Double() {-1, 1})
            Console.WriteLine("{0},{1},{2}", optimization.Result.Eval, optimization.Result(0), optimization.Result(1))
            While (optimization.DoIteration(10) = False)
                Console.WriteLine("{0},{1},{2}", optimization.Result.Eval, optimization.Result(0), optimization.Result(1))
            End While
            clsUtil.DebugValue(optimization)
        End With
        Console.WriteLine("Nelder-Mead - MovePoint")
        With Nothing
            Dim optimization As New clsOptNelderMead(New clsBenchRosenblock(2))
            optimization.Init()
            Console.WriteLine("{0},{1},{2}", optimization.Result.Eval, optimization.Result(0), optimization.Result(1))
            While (optimization.DoIteration(10) = False)
                Console.WriteLine("{0},{1},{2}", optimization.Result.Eval, optimization.Result(0), optimization.Result(1))
            End While
            clsUtil.DebugValue(optimization)
        End With

        'PatternSearch
        Console.WriteLine("HookeJeeves(PatternSearch)")
        For i As Integer = 0 To 5 - 1
            With Nothing
                Dim optimization As New clsOptPatternSearch(New clsBenchRosenblock(2))
                optimization.Init()
                optimization.DoIteration()
                Console.WriteLine("{0},{1}", optimization.Result.Eval, optimization.IterationCount())
            End With
        Next

        Console.WriteLine("Nelder-Mead")
        For i As Integer = 0 To 5 - 1
            With Nothing
                Dim optimization As New clsOptNelderMead(New clsBenchRosenblock(2))
                optimization.Init()
                optimization.DoIteration()
                Console.WriteLine("{0},{1}", optimization.Result.Eval, optimization.IterationCount())
            End With
        Next

        Console.WriteLine("HookeJeeves(PatternSearch) 10D")
        For i As Integer = 0 To 5 - 1
            With Nothing
                Dim optimization As New clsOptPatternSearch(New clsBenchRosenblock(10))
                optimization.Init()
                optimization.DoIteration()
                Console.WriteLine("{0},{1}", optimization.Result.Eval, optimization.IterationCount())
            End With
        Next

        Console.WriteLine("Nelder-Mead 10D")
        For i As Integer = 0 To 5 - 1
            With Nothing
                Dim optimization As New clsOptNelderMead(New clsBenchRosenblock(10))
                optimization.Init()
                optimization.DoIteration()
                Console.WriteLine("{0},{1}", optimization.Result.Eval, optimization.IterationCount())
            End With
        Next

        Console.WriteLine("HookeJeeves(PatternSearch) 20D")
        For i As Integer = 0 To 5 - 1
            With Nothing
                Dim optimization As New clsOptPatternSearch(New clsBenchRosenblock(20))
                optimization.Init()
                optimization.DoIteration()
                Console.WriteLine("{0},{1}", optimization.Result.Eval, optimization.IterationCount())
            End With
        Next

        Console.WriteLine("Nelder-Mead 20D")
        For i As Integer = 0 To 5 - 1
            With Nothing
                Dim optimization As New clsOptNelderMead(New clsBenchRosenblock(20))
                optimization.Init()
                optimization.DoIteration()
                Console.WriteLine("{0},{1}", optimization.Result.Eval, optimization.IterationCount())
            End With
        Next
    End Sub

    Private Sub ComparisonRGA()
        Console.WriteLine("SPX Rastrigin 20D")
        With Nothing
            Dim optimization As New clsOptRealGASPX(New clsBenchRastrigin(20))
            optimization.Init()
            Console.WriteLine("{0},{1}", optimization.Result.Eval, optimization.IterationCount())
            While (optimization.DoIteration(10) = False)
                Console.WriteLine("{0},{1}", optimization.Result.Eval, optimization.IterationCount())
            End While
            If optimization.IsRecentError() = True Then
                Return
            End If
            clsUtil.DebugValue(optimization)
        End With

        Console.WriteLine("REX Rastrigin 20D")
        With Nothing
            Dim optimization As New clsOptRealGAREX(New clsBenchRastrigin(20))
            optimization.Init()
            Console.WriteLine("{0},{1}", optimization.Result.Eval, optimization.IterationCount())
            While (optimization.DoIteration(10) = False)
                Console.WriteLine("{0},{1}", optimization.Result.Eval, optimization.IterationCount())
            End While
            If optimization.IsRecentError() = True Then
                Return
            End If
            clsUtil.DebugValue(optimization)
        End With
    End Sub

    Private Sub OptimizeDeJongFunction()
        With Nothing
            Dim opt As New Optimization.clsOptRealGASPX(New clsBenchDeJongFunction1())
            opt.InitialValueRange = 5.12
            opt.Init()
            clsUtil.DebugValue(opt)
            opt.DoIteration()
            clsUtil.DebugValue(opt)
        End With

        With Nothing
            Dim opt As New Optimization.clsOptRealGASPX(New clsBenchDeJongFunction2())
            opt.InitialValueRange = 2.048
            opt.Init()
            clsUtil.DebugValue(opt)
            opt.DoIteration()
            clsUtil.DebugValue(opt)
        End With

        With Nothing
            Dim opt As New Optimization.clsOptRealGASPX(New clsBenchDeJongFunction3())
            opt.InitialValueRange = 5.12
            opt.Init()

            opt.DoIteration()
            clsUtil.DebugValue(opt)

            opt.UseEliteStrategy(0.2) 'Carry over to the new iteration.
            opt.DoIteration()
            clsUtil.DebugValue(opt)
        End With

        With Nothing
            Dim opt As New Optimization.clsOptRealGASPX(New clsBenchDeJongFunction4())
            opt.InitialValueRange = 1.28
            opt.Init()
            clsUtil.DebugValue(opt)
            opt.DoIteration()
            clsUtil.DebugValue(opt)
        End With

        With Nothing
            Dim opt As New Optimization.clsOptRealGASPX(New clsBenchDeJongFunction5())
            opt.InitialValueRange = 65.536
            opt.ChildrenSize = 100
            opt.Init()
            For i As Integer = 0 To 2
                opt.DoIteration()
                clsUtil.DebugValue(opt, ai_isOutValue:=False)
                opt.UseEliteStrategy(0.1) 'Carry over to the new iteration.
            Next
            clsUtil.DebugValue(opt)
        End With
    End Sub

    Private Sub PSOComparison(ByVal loopCount As Integer, ByVal func As absObjectiveFunction)
        With Nothing
            'Console.WriteLine("BasicPSO")
            Threading.Tasks.Parallel.For(0, loopCount, Sub(i)
                                                           Dim optimization As New clsOptPSO(func)
                                                           optimization.Random = New Util.clsRandomXorshift(CUInt(i * 123456))
                                                           optimization.Iteration = 50000
                                                           optimization.Init()
                                                           optimization.DoIteration()
                                                           Console.WriteLine("{0,20},{1,20},{2},{3}", optimization.GetType().Name, optimization.ObjectiveFunction.GetType().Name, optimization.IterationCount, optimization.Result.Eval)
                                                           'clsUtil.DebugValue(optimization, ai_isOnlyIterationCount:=True)
                                                       End Sub)
        End With
        With Nothing
            'Console.WriteLine("LDIWPSO")
            Threading.Tasks.Parallel.For(0, loopCount, Sub(i)
                                                           Dim optimization As New clsOptPSOLDIW(func)
                                                           optimization.Random = New Util.clsRandomXorshift(CUInt(i * 123456))
                                                           optimization.Iteration = 50000
                                                           optimization.Init()
                                                           optimization.DoIteration()
                                                           Console.WriteLine("{0,20},{1,20},{2},{3}", optimization.GetType().Name, optimization.ObjectiveFunction.GetType().Name, optimization.IterationCount, optimization.Result.Eval)
                                                           'clsUtil.DebugValue(optimization, ai_isOnlyIterationCount:=True)
                                                       End Sub)
        End With
        With Nothing
            'Console.WriteLine("CDIWPSO")
            Threading.Tasks.Parallel.For(0, loopCount, Sub(i)
                                                           Dim optimization As New clsOptPSOChaoticIW(func)
                                                           optimization.Random = New Util.clsRandomXorshift(CUInt(i * 123456))
                                                           optimization.Iteration = 50000
                                                           optimization.Init()
                                                           optimization.DoIteration()
                                                           Console.WriteLine("{0,20}CDIW,{1,20},{2},{3}", optimization.GetType().Name, optimization.ObjectiveFunction.GetType().Name, optimization.IterationCount, optimization.Result.Eval)
                                                           'clsUtil.DebugValue(optimization, ai_isOnlyIterationCount:=True)
                                                       End Sub)
        End With
        With Nothing
            'Console.WriteLine("CRIWPSO")
            Threading.Tasks.Parallel.For(0, loopCount, Sub(i)
                                                           Dim optimization As New clsOptPSOChaoticIW(func)
                                                           optimization.ChaoticMode = clsOptPSOChaoticIW.EnumChaoticInertiaWeightMode.CRIW
                                                           optimization.Random = New Util.clsRandomXorshift(CUInt(i * 123456))
                                                           optimization.Iteration = 50000
                                                           optimization.Init()
                                                           optimization.DoIteration()
                                                           Console.WriteLine("{0,20}CRIW,{1,20},{2},{3}", optimization.GetType().Name, optimization.ObjectiveFunction.GetType().Name, optimization.IterationCount, optimization.Result.Eval)
                                                           'clsUtil.DebugValue(optimization, ai_isOnlyIterationCount:=True)
                                                       End Sub)
        End With
        With Nothing
            'Console.WriteLine("AIWPSO")
            Threading.Tasks.Parallel.For(0, loopCount, Sub(i)
                                                           Dim optimization As New clsOptPSOAIW(func)
                                                           optimization.Random = New Util.clsRandomXorshift(CUInt(i * 123456))
                                                           optimization.Iteration = 50000
                                                           optimization.Init()
                                                           optimization.DoIteration()
                                                           Console.WriteLine("{0,20},{1,20},{2},{3}", optimization.GetType().Name, optimization.ObjectiveFunction.GetType().Name, optimization.IterationCount, optimization.Result.Eval)
                                                           'clsUtil.DebugValue(optimization, ai_isOnlyIterationCount:=True)
                                                       End Sub)
        End With
    End Sub
End Module
