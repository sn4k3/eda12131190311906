/**
 * 
 */

/**
 * @author Tiago Conceição Nº 11903
 * @author Gonçalo Lampreia Nº 11906
 */
public class Profiler {
	/**
	 * Start time
	 */
	private long startTime;
	/**
	 * End time
	 */
	private long endTime;
	/**
	 * Is running?
	 */
	private boolean isRunning;
	
	/**
	 * Constructor
	 */
	public Profiler() {
		this(true);
	}
	
	/**
	 * Constructor
	 * @param run True to start profiling, otherwise false (Call Start())
	 */
	public Profiler(boolean run) {
		this.startTime = run ? System.nanoTime() : 0;
		this.endTime = 0;
		this.isRunning = run;
	}
	
	/**
	 * Reset timers
	 */
	public void reset()
	{
		this.startTime = this.endTime = 0;
		this.isRunning = false;
	}
	
	/**
	 * Get if profiler has start measuring execution time
	 * @return True if has started, otherwise false
	 */
	public boolean hasStarted()
	{
		return this.startTime != 0;
	}
	
	/**
	 * Start profiling
	 * @return True if starts, otherwise false (Already running)
	 */
	public boolean start()
	{
		if(this.isRunning)
		{
			return false;
		}
		this.startTime = System.nanoTime();
		return true;
	}
	
	/**
	 * Stop profiling
	 * @return Executing time
	 */
	public long stop()
	{
		if(!this.isRunning)
		{
			return this.getExecutionTime();
		}
		this.isRunning = false;
		this.endTime = System.nanoTime();
		
		return endTime - startTime;
	}
	
	/**
	 * Get start time
	 * @return Time in nanoseconds
	 */
	public long getStartTime()
	{
		return this.startTime;
	}
	
	/**
	 * Get end time
	 * @return Time in nanoseconds
	 */
	public long getEndTime()
	{
		return this.endTime;
	}
	
	/**
	 * Get execution time until now or until stop
	 * @return Time in nanoseconds
	 */
	public long getExecutionTime()
	{
		if(this.startTime == 0)
		{
			return 0;
		}
		if(this.endTime == 0)
		{
			return System.nanoTime() - this.startTime;
		}
		return this.endTime - this.startTime;
	}
	
	/**
	 * Get execution time until now or until stop
	 * @return Time in milliseconds
	 */
	public double getExecutionMilliTime()
	{
		long time = this.getExecutionTime();
		if(time == 0)
		{
			return 0D;
		}
		return time / 1000000.0;
	}
	
	/**
	 * Get if profiling still running
	 * @return True if is running, otherwise false
	 */
	public boolean isRunning()
	{
		return this.isRunning;
	}
	
	/**
	 * Print execution time to console
	 * @param message
	 */
	public void printToConsole(String message)
	{
		this.printToConsole(message, true);
	}
	
	/**
	 * Print execution time to console
	 * @param message
	 */
	public void printToConsole(String message, boolean inMilliseconds)
	{
		long executionTime = this.getExecutionTime();

		if(executionTime == 0)
		{
			return;
		}
		
		System.out.println(message +
				(inMilliseconds ? executionTime / 1000000.0D : 
								 executionTime) +
				(inMilliseconds ? " ms" : 
								 " ns"));
	}
}
