using System;
using System.IO;

namespace MemoryLeaks.MemoryLeak.Disposable
{
    internal class DisposeLeak : IDisposable
    {
        private MemoryStream _memorySteam;
        private bool _disposedValue;

        public DisposeLeak()
        {
            _memorySteam = new MemoryStream(409600);
            _memorySteam.Write(new byte[409600]);
        }
        ~DisposeLeak()
        {
            Console.WriteLine($"Released {nameof(DisposeLeak)}");
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // TODO: 관리형 상태(관리형 개체)를 삭제합니다.
                }
                _memorySteam.Dispose();
                // TODO: 비관리형 리소스(비관리형 개체)를 해제하고 종료자를 재정의합니다.
                // TODO: 큰 필드를 null로 설정합니다.
                _disposedValue = true;
            }
        }

        // // TODO: 비관리형 리소스를 해제하는 코드가 'Dispose(bool disposing)'에 포함된 경우에만 종료자를 재정의합니다.
        // ~DisposeLeak()
        // {
        //     // 이 코드를 변경하지 마세요. 'Dispose(bool disposing)' 메서드에 정리 코드를 입력합니다.
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // 이 코드를 변경하지 마세요. 'Dispose(bool disposing)' 메서드에 정리 코드를 입력합니다.
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
